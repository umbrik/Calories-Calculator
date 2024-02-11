using Calories_Calculator.Database;
using Calories_Calculator.Entities;
using Calories_Calculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calories_Calculator.Controllers;

[ApiController]
[Route("[controller]")]
public class MealController : ControllerBase
{
    private readonly ILogger<MealController> _logger;
    private readonly ApplicationContext _context;

    public MealController(ILogger<MealController> logger,
        ApplicationContext dbContext)
    {
        _logger = logger;
        _context = dbContext;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.Meals.Where(x => x.PersonId == 1));
    }

    [HttpPut]
    public IActionResult Put([FromBody] PutMealDto meal)
    {
        _context.Add<Meal>(new()
        {
            PersonId = meal.PersonId,
            FoodId = meal.FoodId,
            Weight = meal.Weight,
        });

        return Ok("Created");
    }
}
