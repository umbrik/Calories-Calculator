namespace Calories_Calculator.Models;

public class Meal : BaseEntity
{
    public int Id { get; set; }
    public required int PersonId { get; set; }
    public Person Person { get; set; } = null!;
    public required int FoodId { get; set; }
    public Food Food { get; set; } = null!;
    public required float Weight { get; set; }
}
