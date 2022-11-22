using LexiconMVC.Data;
using LexiconMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(15);
});
builder.Services.AddScoped<IGuessingRepository, GuessingRepository>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure(maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null);
        });
  
});
var app = builder.Build();

app.UseSession();
app.UseStaticFiles();
app.UseRouting();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    DbInitializer.Seed(app);
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
