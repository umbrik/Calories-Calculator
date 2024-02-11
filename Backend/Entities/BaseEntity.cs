using System.ComponentModel.DataAnnotations;

namespace Calories_Calculator.Entities;

public class BaseEntity
{
    [Required]
    public DateTime? CreatedAt { get; set; }
    [Required]
    public DateTime? UpdatedAt { get; set; }
}
