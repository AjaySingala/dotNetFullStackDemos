using Microsoft.OpenApi.Models;
// using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Swagger generator.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddSwaggerGen(options =>
// {
//     options.SwaggerDoc("v1", new OpenApiInfo
//     {
//         Version = "v1",
//         Title = "Person API",
//         Description = "An ASP.NET Core Web API for managing ToDo items",
//         TermsOfService = new Uri("https://ajaysingala.com/terms"),
//         Contact = new OpenApiContact
//         {
//             Name = "Example Contact",
//             Url = new Uri("https://ajaysingala.com/contact")
//         },
//         License = new OpenApiLicense
//         {
//             Name = "Example License",
//             Url = new Uri("https://ajaysingala.com/license")
//         }
//     });

//     var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//     Console.WriteLine(xmlFilename);
//     Console.WriteLine(Path.Combine(AppContext.BaseDirectory, xmlFilename));
//     options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
// });

var app = builder.Build();

// // Enable the middleware for serving the generated JSON document and the Swagger UI.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
