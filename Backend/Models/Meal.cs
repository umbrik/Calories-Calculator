using Calories_Calculator.Entities;

namespace Calories_Calculator.Models;

public class GetMealDto
{
    public int PersonId { get; set; }
}

public class PutMealDto
{
    public int PersonId { get; set; }
    public int FoodId { get; set; }
    public float Weight { get; set; }
}

public class MealDto
{
    public int Id { get; set; }
    public required int PersonId { get; set; }
    public required int FoodId { get; set; }
    public Food Food { get; set; } = null!;
    public required float Weight { get; set; }

    public static explicit operator MealDto(Meal v) => new()
    {
        Id = v.Id,
        PersonId = v.PersonId,
        FoodId = v.FoodId,
        Food = v.Food,
        Weight = v.Weight,
    };
}
