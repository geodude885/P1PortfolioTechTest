using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using P1Portfolio.Clients;
using P1Portfolio.Configuration;
using P1Portfolio.Services;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var secclSettings = configuration.GetSection("SecclApi").Get<SecclApiSettings>();
if (secclSettings == null) throw new ArgumentNullException(nameof(secclSettings), "SeeclApi section was not found in appsettings.json");

builder.Services.AddSingleton(secclSettings);
builder.Services.AddHttpClient<SecclApiClient>(client =>
{
    client.BaseAddress = new Uri(secclSettings.ApiBaseUri);
});
builder.Services.AddTransient<ISecclService, SecclService>();

builder.Services.AddServerSideBlazor();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
