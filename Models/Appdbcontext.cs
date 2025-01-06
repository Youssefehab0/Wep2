using Gadara2.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gadara2.Models
{
    public class Appdbcontext : DbContext
    {
        public Appdbcontext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Taskk> Taskk { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(c=>c.taskks).WithOne(c=>c.User).HasForeignKey(c=>c.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Projects>().HasMany(c=>c.taskks).WithOne(c=>c.Projects).HasForeignKey(c=>c.ProjectId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
