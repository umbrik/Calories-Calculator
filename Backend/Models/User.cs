using Microsoft.AspNetCore.Identity;

namespace Calories_Calculator.Models;

public class User : IdentityUser
{
    public Person? Person { get; set; }
    public DateOnly CreatedAt { get; set; }
    public DateOnly UpdatedAt { get; set; }
}
