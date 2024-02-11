﻿using Calories_Calculator.Database;
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
    public bool Put([FromQuery] int personId,
        [FromQuery] int foodId,
        [FromQuery] float weight)
    {
        _context.Add<Meal>(new()
        {
            PersonId = personId,
            FoodId = foodId,
            Weight = weight,
        });

        return _context.SaveChanges() == 1;
    }
}