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
}
