using System.Text.Json.Serialization;

namespace Calories_Calculator.Entities;

public class Meal : BaseEntity
{
    public int Id { get; set; }
    public required int PersonId { get; set; }
    [JsonIgnore]
    public Person Person { get; set; } = null!;
    public required int FoodId { get; set; }
    [JsonIgnore]
    public Food Food { get; set; } = null!;
    public required float Weight { get; set; }
}
