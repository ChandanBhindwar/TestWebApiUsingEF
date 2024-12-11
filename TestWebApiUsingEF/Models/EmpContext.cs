using Microsoft.EntityFrameworkCore;

namespace TestWebApiUsingEF.Models
{
    public class EmpContext : DbContext
    {
        public EmpContext(DbContextOptions options) : base(options) { }

        DbSet<Employees> Employees { get; set; }
    }
}
