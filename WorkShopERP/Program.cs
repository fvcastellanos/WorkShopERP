using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Steeltoe.Extensions.Configuration.Placeholder;
using Steeltoe.Connector.MySql.EF6;

using WorkShopERP.Data;
using WorkShopERP.Model;

var builder = WebApplication.CreateBuilder(args);

// Add placeholder resolver
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddPlaceholderResolver();

// Add services to the container.

var configuration = builder.Configuration;

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<WorkShopERPContext>(configuration);

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
