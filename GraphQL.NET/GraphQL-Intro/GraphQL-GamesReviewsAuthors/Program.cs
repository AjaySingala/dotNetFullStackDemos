using GraphQL_GamesReviewsAuthors.GraphQL.Mutations;
using GraphQL_GamesReviewsAuthors.GraphQL.Queries;
using GraphQL_GamesReviewsAuthors.Repositories;
using GraphQL_GamesReviewsAuthors.Schema;

namespace GraphQL_GamesReviewsAuthors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Register repositories.
            builder.Services.AddScoped<IGameRepository, GameRepository>();
            builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

            // Regiter the GraphQL server and queries/mutations.
            builder.Services.AddGraphQLServer()
                .AddQueryType(q => q.Name("Query"))
                    .AddTypeExtension<GameGraphQLQueries>()
                    .AddTypeExtension<ReviewGraphQLQueries>()
                    .AddTypeExtension<AuthorGraphQLQueries>()
                .AddMutationType(m => m.Name("Mutation"))
                    .AddTypeExtension<GameMutations>()
                .AddType<GameType>()
                .AddType<ReviewType>()
                .AddType<AuthorType>()
                .AddInMemorySubscriptions();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.MapGraphQL();

            app.Run();
        }
    }
}