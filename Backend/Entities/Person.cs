namespace Calories_Calculator.Entities;

public class Person : BaseEntity
{
    public int Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string Fullname
    {
        get => string.Join(" ", [Firstname, Lastname]);
    }
    public string? UserId { get; set; }
    public User? User { get; set; } = null!;
    public ICollection<Meal> Meals { get; } = new List<Meal>();
}
