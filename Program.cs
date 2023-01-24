using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorApp;
using BlazorApp.Data;
<<<<<<< HEAD
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
=======
using MudBlazor.Services;
>>>>>>> 95ac225 (Setup MudBlazor following installation instructions)

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;
Console.WriteLine(Configuration["OpenIDConnect:ClientSecret"]);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<GeneratedNameService>();
builder.Services.AddMudServices();
builder.Services.AddHttpClient();

builder.Services.AddSingleton<TokenClient>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    options.Cookie.SameSite = SameSiteMode.Strict;
})
.AddOpenIdConnect(options =>
{
    options.NonceCookie.SameSite = SameSiteMode.Strict;
    options.CorrelationCookie.SameSite = SameSiteMode.Strict;

    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

    options.Authority = Configuration["OpenIDConnect:Issuer"];
    options.ClientId = Configuration["OpenIDConnect:ClientId"];
    options.ClientSecret = Configuration["OpenIDConnect:ClientSecret"];
    options.ResponseType = OpenIdConnectResponseType.Code;
    options.ResponseMode = OpenIdConnectResponseMode.Query;
    options.GetClaimsFromUserInfoEndpoint = true;

    options.RequireHttpsMetadata = false;

    string scopeString = Configuration["OpenIDConnect:Scope"];
    scopeString.Split(" ", StringSplitOptions.TrimEntries).ToList().ForEach(scope => {
        options.Scope.Add(scope);
    });

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = options.Authority,
        ValidAudience = options.ClientId
    };

    options.Events.OnRedirectToIdentityProviderForSignOut = (context) =>
    {
        context.ProtocolMessage.PostLogoutRedirectUri = Configuration["OpenIDConnect:PostLogoutRedirectUri"];
        return Task.CompletedTask;
    };

    options.SaveTokens = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
