using EFCoreAPICodeFirstSample.Extensions;
using EFCoreAPICodeFirstSample.Models;
using EFCoreAPICodeFirstSample.Models.DataManager;
using EFCoreAPICodeFirstSample.Models.Repository;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors(); 
builder.Services.ConfigureIISIntegration();

// DB Context.
var connValue = builder.Configuration.GetValue<string>("ConnectionString:EmployeeDB");
builder.Services.AddDbContext<EmployeeContext>(opts => 
    opts.UseSqlServer(connValue)
);
builder.Services.AddScoped<IDataRepository<Employee>, EmployeeManager>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else 
    app.UseHsts();

app.UseHttpsRedirection();

// Useful for Linux deployment.
app.UseForwardedHeaders(new ForwardedHeadersOptions 
{ 
    ForwardedHeaders = ForwardedHeaders.All 
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
