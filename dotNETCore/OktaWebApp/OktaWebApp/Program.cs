using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Okta.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// BEGIN: OKTA Config.
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
})
      .AddAuthentication(options =>
      {
          options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
          options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
      })
  .AddCookie()
  .AddOktaMvc(new OktaMvcOptions
  {
      // Replace these values with your Okta configuration
      OktaDomain = builder.Configuration.GetValue<string>("Okta:OktaDomain"),
      AuthorizationServerId = builder.Configuration.GetValue<string>("Okta:AuthorizationServerId"),
      ClientId = builder.Configuration.GetValue<string>("Okta:ClientId"),
      ClientSecret = builder.Configuration.GetValue<string>("Okta:ClientSecret"),
      Scope = new List<string> { "openid", "profile", "email" },
  });
// END: OKTA Config.

// BEGIN: OKTA Authentication for everything.
builder.Services.AddMvc(o =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    o.Filters.Add(new AuthorizeFilter(policy));
});
// END: OKTA Authentication for everything.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// BEGIN: OKTA.
app.UseAuthentication();
// END: OKTA.

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
