using Calories_Calculator.Database;
using Calories_Calculator.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ApplicationContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationContext>();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    var person = context.Add<Person>(new()
    {
        Firstname = "admin",
        Lastname = "admin"
    });

    context.Add<User>(new()
    {
        Person = person.Entity
    });

    List<Food> foods = new()
    {
        new()
        {
            Name = "Молоко",
            Calories = 152,
            Protein = 7.9F,
            Fat = 8.1F,
            Carbohydrate = 12,
            Fiber = 0,
            Sugar = 12,
        },
        new()
        {
            Name = "Картофель",
            Calories = 22,
            Protein = 1,
            Fat = 0,
            Carbohydrate = 4.7F,
            Fiber = 1,
            Sugar = 0,
        },
        new()
        {
            Name = "Бананы",
            Calories = 200,
            Protein = 2.5F,
            Fat = 0.3F,
            Carbohydrate = 51,
            Fiber = 5.9F,
            Sugar = 28,
        },
        new()
        {
            Name = "Рис длиннозерный",
            Calories = 679,
            Protein = 14,
            Fat = 1.1F,
            Carbohydrate = 141,
            Fiber = 6.7F,
            Sugar = 1.2F,
        }
    };

    context.AddRange(foods);

    context.SaveChanges();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
