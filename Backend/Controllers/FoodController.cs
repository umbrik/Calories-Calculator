using Calories_Calculator.Database;
using Calories_Calculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calories_Calculator.Controllers;

[ApiController]
[Route("[controller]")]
public class FoodController : ControllerBase
{
    private readonly ILogger<FoodController> _logger;
    private readonly ApplicationContext _context;

    public FoodController(ILogger<FoodController> logger,
        ApplicationContext dbContext)
    {
        _logger = logger;
        _context = dbContext;
    }

    [HttpGet]
    public IEnumerable<Food> Get()
    {
        return _context.Foods.ToList();
    }

    [HttpPut]
    public bool Put([FromQuery] string name,
        [FromQuery] float calories,
        [FromQuery] float protein,
        [FromQuery] float fat,
        [FromQuery] float carbohydrate,
        [FromQuery] float fiber,
        [FromQuery] float sugar)
    {
        _context.Add<Food>(new()
        {
            Name = name,
            Calories = calories,
            Protein = protein,
            Fat = fat,
            Carbohydrate = carbohydrate,
            Fiber = fiber,
            Sugar = sugar,
        });

        return _context.SaveChanges() == 1;
    }

    [HttpPatch]
    public IActionResult Patch([FromQuery] int id,
        [FromQuery] string? name,
        [FromQuery] float? calories,
        [FromQuery] float? protein,
        [FromQuery] float? fat,
        [FromQuery] float? carbohydrate,
        [FromQuery] float? fiber,
        [FromQuery] float? sugar)
    {
        var updatedFood = _context.Foods.FirstOrDefault(x => x.Id == id);

        if (updatedFood is null)
        {
            return NotFound();
        }

        if (name is not null)
        {
            updatedFood.Name = name;
        }

        if (calories is not null)
        {
            updatedFood.Calories = (float)calories;
        }

        if (protein is not null)
        {
            updatedFood.Protein = (float)protein;
        }

        if (fat is not null)
        {
            updatedFood.Fat = (float)fat;
        }

        if (carbohydrate is not null)
        {
            updatedFood.Carbohydrate = (float)carbohydrate;
        }

        if (fiber is not null)
        {
            updatedFood.Fiber = (float)fiber;
        }

        if (sugar is not null)
        {
            updatedFood.Sugar = (float)sugar;
        }

        return Ok(_context.SaveChanges() == 1);
    }
}
