using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Steeltoe.Extensions.Configuration.Placeholder;

using WorkShopERP.Data;
using WorkShopERP.Model;
using WorkShopERP.Services;
using Steeltoe.Connector.MySql.EFCore;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Auth0.AspNetCore.Authentication;
using WorkShopERP;


var builder = WebApplication.CreateBuilder(args);

// Add placeholder resolver
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddPlaceholderResolver();

// Add services to the container.

var configuration = builder.Configuration;

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddBlazorise(options =>
{
    options.Immediate = true;
}).AddBootstrap5Providers()
    .AddFontAwesomeIcons();

builder.Services.AddDbContext<WorkShopERPContext>(options => {

    options.UseMySql(configuration);

});

builder.Services.AddAuth0WebAppAuthentication(options => {
    options.Domain = configuration["Auth0:Domain"];
    options.ClientId = configuration["Auth0:ClientId"];

});

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CarBrandService>();

builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
