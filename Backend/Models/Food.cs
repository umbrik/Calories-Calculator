using System.ComponentModel.DataAnnotations;
using Calories_Calculator.Entities;

namespace Calories_Calculator.Models;

public class GetFood
{
    public int? Id { get; set; }
}

public class PutFood
{
    [MinLength(3)]
    public string Name { get; set; }
    public float Calories { get; set; }
    public float Protein { get; set; }
    public float Fat { get; set; }
    public float Carbohydrate { get; set; }
    public float Fiber { get; set; }
    public float Sugar { get; set; }
}

public class PatchFood
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public float? Calories { get; set; }
    public float? Protein { get; set; }
    public float? Fat { get; set; }
    public float? Carbohydrate { get; set; }
    public float? Fiber { get; set; }
    public float? Sugar { get; set; }
}

public class FoodDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public float Calories { get; set; }
    public float Protein { get; set; }
    public float Fat { get; set; }
    public float Carbohydrate { get; set; }
    public float Fiber { get; set; }
    public float Sugar { get; set; }

    public static explicit operator FoodDto(Food v)
    {
        return new FoodDto()
        {
            Id = v.Id,
            Name = v.Name,
            Calories = v.Calories,
            Protein = v.Protein,
            Fat = v.Fat,
            Carbohydrate = v.Carbohydrate,
            Fiber = v.Fiber,
            Sugar = v.Sugar,
        };
    }
}
