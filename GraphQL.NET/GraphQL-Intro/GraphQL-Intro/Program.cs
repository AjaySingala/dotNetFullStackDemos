using GraphQL_Intro;
using HotChocolate.AspNetCore.Playground;
using HotChocolate.AspNetCore;
using HotChocolate.Subscriptions;
using GraphQL_Intro.Repositories.Interfaces;
using GraphQL_Intro.Repositories;
using GraphQL_Intro.GraphQL.Queries;
using GraphQL_Intro.GraphQL.Books;
using GraphQL_Intro.GraphQL.Mutations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

//builder.Services.AddGraphQLServer()
//    .AddType<SupplierType>()
//    .AddQueryType<SupplierGraphQLQuery>()
//    .AddSubscriptionType<SupplierSubscription>()
//    .AddInMemorySubscriptions();

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddInMemorySubscriptions();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.UsePlayground(new PlaygroundOptions
{
    QueryPath = "/graphql",
    Path = "/playground"
});

app.MapGraphQL();

app.Run();
