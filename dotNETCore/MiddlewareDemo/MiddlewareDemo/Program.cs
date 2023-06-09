var builder = WebApplication.CreateBuilder(args);

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

app.MapRazorPages();

#region Demo1

//app.Run(async context =>
//{
//    await context.Response.WriteAsync("Hello world!");
//});

//app.Run();

#endregion

#region Demo2

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello World From 1st Middleware");
//});

//// The following will never be executed
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Hello World From 2nd Middleware");
//});

//app.Run();

#endregion

#region Demo3

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Hello World From 1st Middleware!");

//    await next();
//});

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("\nHello World From 2nd Middleware");
//});

//app.Run();

#endregion

#region Demo4

app.Map("/map1", HandleMapTest1);

app.Map("/map2", HandleMapTest2);

app.Run(async context =>
{
    await context.Response.WriteAsync("<p>Hello from non-Map delegate.</p>");
});

app.Run();

static void HandleMapTest1(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map Test 1");
    });
}

static void HandleMapTest2(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map Test 2");
    });
}

#endregion


