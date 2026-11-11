using Microsoft.EntityFrameworkCore;
using AuthServer.Models;

namespace AuthServer
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Faculty> Faculties => Set<Faculty>();
        public DbSet<Class> Classes => Set<Class>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<AccountRole> AccountRoles => Set<AccountRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountRole>()
                .HasKey(ar => new { ar.UserId, ar.RoleId });

            modelBuilder.Entity<Class>()
                .HasOne(c => c.Faculty)
                .WithMany(f => f.Classes)
                .HasForeignKey(c => c.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Faculty)
                .WithMany(f => f.Users)
                .HasForeignKey(u => u.FacultyId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Class)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.ClassId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Position)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.PositionId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}