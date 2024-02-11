using Calories_Calculator.Database;
using Calories_Calculator.Entities;
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
    public IEnumerable<Food> Get([FromBody] GetFood? food)
    {
        if (food?.Id is null)
        {
            return _context.Foods.ToList();
        }
        else
        {
            return _context.Foods.Where(x => x.Id == food.Id).ToList();
        }
    }

    [HttpPut]
    public bool Put([FromBody] PutFood food)
    {
        _context.Add<Food>(new()
        {
            Name = food.Name,
            Calories = food.Calories,
            Protein = food.Protein,
            Fat = food.Fat,
            Carbohydrate = food.Carbohydrate,
            Fiber = food.Fiber,
            Sugar = food.Sugar,
        });

        return _context.SaveChanges() == 1;
    }

    [HttpPatch]
    public IActionResult Patch([FromBody] PatchFood food)
    {
        var foodEntity = _context.Foods.Find(food.Id);

        if (foodEntity is null)
        {
            return NotFound();
        }

        foodEntity.Name = food.Name ?? foodEntity.Name;
        foodEntity.Calories = food.Calories ?? foodEntity.Calories;
        foodEntity.Protein = food.Protein ?? foodEntity.Protein;
        foodEntity.Fat = food.Fat ?? foodEntity.Fat;
        foodEntity.Carbohydrate = food.Carbohydrate ?? foodEntity.Carbohydrate;
        foodEntity.Fiber = food.Fiber ?? foodEntity.Fiber;
        foodEntity.Sugar = food.Sugar ?? foodEntity.Sugar;
        return Ok(_context.SaveChanges() == 1);
    }
}
