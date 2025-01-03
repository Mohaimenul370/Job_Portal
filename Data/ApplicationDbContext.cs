using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using JP2.Models;

namespace JP2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<JP2.Models.Application>? Application { get; set; }
        public DbSet<JP2.Models.Catagory>? Catagory { get; set; }
        public DbSet<JP2.Models.Employer>? Employer { get; set; }
        public DbSet<JP2.Models.Job>? Job { get; set; }
        public DbSet<JP2.Models.User>? User { get; set; }
    }
}