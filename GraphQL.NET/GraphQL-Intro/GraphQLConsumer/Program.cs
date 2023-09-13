using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQLConsumer.Queries;

namespace GraphQLConsumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

                        var graphQLURI = builder.Configuration["GraphQLURI"];
            builder.Services.AddScoped<IGraphQLClient>(
                s => new GraphQLHttpClient(graphQLURI, new NewtonsoftJsonSerializer())
            );
            builder.Services.AddScoped<GameConsumer>();

            builder.Services.AddControllers();

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.MapRazorPages();

            app.Run();
        }
    }
}