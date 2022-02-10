using FilterDemos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// For Global Filter.
//builder.Services.AddControllers(config =>
//    {
//        config.Filters.Add(new SampleActionFilter());
//    }
//);

// For Service Filter Attribute.
builder.Services.AddScoped<LoggingResponseHeaderFilterService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
