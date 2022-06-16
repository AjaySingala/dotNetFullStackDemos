using Okta.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// BEGIN: For Okta Authorization.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = OktaDefaults.ApiAuthenticationScheme;
    options.DefaultChallengeScheme = OktaDefaults.ApiAuthenticationScheme;
    options.DefaultSignInScheme = OktaDefaults.ApiAuthenticationScheme;
})
    .AddOktaWebApi(new OktaWebApiOptions()
    {
        OktaDomain = builder.Configuration.GetValue<string>("Okta:OktaDomain"),
        AuthorizationServerId = builder.Configuration.GetValue<string>("Okta:AuthorizationServerId"),
        Audience = builder.Configuration.GetValue<string>("Okta:Audience")
    });
builder.Services.AddAuthorization();
// END: For Okta Authorization.

// BEGIN: For Okta Authorization.
// Require authorization for everything.
builder.Services.AddMvc(o =>
{
    var policy = new AuthorizationPolicyBuilder()
      .RequireAuthenticatedUser()
      .Build();
    o.Filters.Add(new AuthorizeFilter(policy));
});
// END: For Okta Authorization.

// BEGIN: CORS.
builder.Services.AddCors(options =>
{
    // The CORS policy is open for testing purposes. In a production application, you should restrict it to known origins.
    options.AddPolicy(
       "AllowAll",
       builder => builder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader());
});
// END: CORS.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

// BEGIN: For Okta Authorization.
app.UseAuthentication();
// END: For Okta Authorization.
app.UseAuthorization();


app.MapControllers();

app.Run();
