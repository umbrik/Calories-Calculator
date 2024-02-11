namespace Calories_Calculator.Models;

public class Food : BaseEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required float Calories { get; set; }
    public required float Protein { get; set; }
    public required float Fat { get; set; }
    public required float Carbohydrate { get; set; }
    public required float Fiber { get; set; }
    public required float Sugar { get; set; }
}
