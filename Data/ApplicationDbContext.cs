using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Test.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public IOptions<AppSettings> Options { get; }
        public ApplicationDbContext(IOptions<AppSettings> options)
        {
            Options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptions)
        {
            dbContextOptions.UseSqlServer(Options.Value.DefaultConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Student>(new StudentConfiguration());

            modelBuilder.ApplyConfiguration<Grade>(new GradeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Grade> Grades { get; set; }
    }
}
