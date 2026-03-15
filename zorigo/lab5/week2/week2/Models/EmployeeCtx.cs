using Microsoft.EntityFrameworkCore;

namespace week2.Models
{
    public class EmployeeCtx : DbContext
    {
        public EmployeeCtx(DbContextOptions<EmployeeCtx> options) : base(options) { }

        public DbSet<Branch> branches { get; set; }
        public DbSet<Worker> workers { get; set; }
    }
}