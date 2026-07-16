using Microsoft.EntityFrameworkCore;
using UserDirectoryManagement.Domain.Models;               // replace with your model namespace

namespace UserDirectoryManagement.Repository
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
            : base(options){}
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");

            modelBuilder.Entity<User>().Property(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Name);
            modelBuilder.Entity<User>().Property(u => u.Age);
            modelBuilder.Entity<User>().Property(u => u.City);
            modelBuilder.Entity<User>().Property(u => u.State);
            modelBuilder.Entity<User>().Property(u => u.Pincode);
        }

    }
}
