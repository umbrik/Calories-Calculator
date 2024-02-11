namespace Calories_Calculator.Models;

public class Food : BaseEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int Calories { get; set; }
    public required int Protein { get; set; }
    public required int Fat { get; set; }
    public required int Carbohydrate { get; set; }
    public required int Fiber { get; set; }
    public required int Sugar { get; set; }
}
