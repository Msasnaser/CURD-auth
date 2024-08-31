using CURD.Models;
using Microsoft.EntityFrameworkCore;

namespace CURD.Data
{
    public class ApplicationDbContext :DbContext
    {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
        
        
        public DbSet<Employee> Employees { get; set; }  
        public DbSet<User> Users { get; set; }
    }
}
