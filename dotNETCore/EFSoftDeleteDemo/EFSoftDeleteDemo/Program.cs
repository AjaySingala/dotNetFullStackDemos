//Install-Package Microsoft.EntityFrameworkCore
//Install-Package Microsoft.EntityFrameworkCore.InMemory

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;
using System.Reflection.Emit;
// save test data of movies
Movies.Initialize();
var db = new Database();
var firstMovie = db.Movies.First();
Console.WriteLine($"{firstMovie.Title} ({firstMovie.ReleaseYear})");
// delete operation
db.Movies.Remove(firstMovie);
db.SaveChanges();
Console.WriteLine($"Deleted \"{firstMovie}\"");
Console.WriteLine($"Total Movies: {db.Movies.Count()}");
Console.WriteLine($"Total Movies (including deleted): {db.Movies.IgnoreQueryFilters().Count()}");
Console.WriteLine($"Total Deleted: {db.Movies.IgnoreQueryFilters().Count(x => x.IsDeleted)}");

public static class Movies
{
    public static readonly IReadOnlyList<Movie> All = new List<Movie> {
        new() { Id = 1, Title = "Glass Onion", Director = "Rian Johnson", Writer = "Rian Johnson", ReleaseYear = 2022 },
        new() { Id = 2, Title = "Avatar: The Way of Water", Director ="James Cameron", Writer = "James Cameron", ReleaseYear = 2022 },
        new() { Id = 3, Title = "The Shawshank Redemption", Writer = "Stephen King", Director = "Frank Darabont", ReleaseYear = 1994 },
        new() { Id = 4, Title = "Pulp Fiction", Writer = "Quentin Tarantino", Director = "Quentin Tarantino", ReleaseYear = 1994 },
        new() { Id = 5, Title = "Seven Samurai", Writer = "Akira Kurosawa", Director = "Akira Kurosawa", ReleaseYear = 1954 },
        new() { Id = 6, Title = "Gladiator", Writer = "David Franzoni", Director = "Ridley Scott", ReleaseYear = 2000 },
        new() { Id = 7, Title = "Old Boy", Writer = "Garon Tsuchiya", Director = "Park Chan-wook", ReleaseYear = 2003 },
        new() { Id = 8, Title = "A Clockwork Orange", Director = "Stanley Kubrick", Writer = "Stanley Kubrick", ReleaseYear = 1971 },
        new() { Id = 9, Title = "Metroplis", Director = "Fritz Lang", Writer = "Thea von Harbou", ReleaseYear = 1927 },
        new() { Id = 10, Title = "The Thing", Director = "John Carpenter", Writer = "Bill Lancaster", ReleaseYear = 1982 }
    };

    public static void Initialize()
    {
        var db = new Database();
        db.Movies.AddRange(All);
        db.SaveChanges();
    }
}
public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        if (eventData.Context is null) return result;

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            if (entry is not { State: EntityState.Deleted, Entity: ISoftDelete delete }) continue;
            entry.State = EntityState.Modified;
            delete.IsDeleted = true;
            delete.DeletedAt = DateTimeOffset.UtcNow;
        }
        return result;
    }
}

public class Database : DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseInMemoryDatabase("test")
            .AddInterceptors(new SoftDeleteInterceptor());
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .HasQueryFilter(x => x.IsDeleted == false);
    }
}

public class Movie : ISoftDelete
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Writer { get; set; } = "";
    public string Director { get; set; } = "";
    public int ReleaseYear { get; set; }

    public override string ToString()
        => $"{Id}: {Title} ({ReleaseYear})";
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
}

public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public void Undo()
    {
        IsDeleted = false;
        DeletedAt = null;
    }
}