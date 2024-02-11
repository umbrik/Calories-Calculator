using Microsoft.AspNetCore.Identity;

namespace Calories_Calculator.Models;

public class IdentityBaseEntity : IdentityUser
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

public class User : IdentityBaseEntity
{
    public Person? Person { get; set; }
}
