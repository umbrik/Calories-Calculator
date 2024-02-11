namespace Calories_Calculator.Models;

public class Person
{
    public int Id { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string Fullname {
        get => string.Join(" ", [Firstname, Lastname]);
    }
    public string? UserId { get; set; }
    public User? User { get; set; } = null!;
    public DateOnly CreatedAt { get; set; }
    public DateOnly UpdatedAt { get; set; }
}
