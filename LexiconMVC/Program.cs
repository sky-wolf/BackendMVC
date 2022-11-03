using LexiconMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(15);
});
builder.Services.AddScoped<IGuessingRepository, GuessingRepository>();

var app = builder.Build();

app.UseSession();
app.UseStaticFiles();
app.UseRouting();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapControllerRoute(
    name: "GuessingGame",
    pattern: "GuessingGame",
    defaults: new { controller = "Guessing", action = "Guess" });

app.MapControllerRoute(
    name: "FeverCheck",
    pattern: "FeverCheck",
    defaults: new {controller = "Feber", action = "Check" });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
