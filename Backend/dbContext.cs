using Calories_Calculator.Models;
using Microsoft.EntityFrameworkCore;

namespace Calories_Calculator.Database
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext (DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
