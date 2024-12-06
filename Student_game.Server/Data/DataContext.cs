using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Student_game.Server.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Account> Accounts {get; set;}
        public DbSet<Armour> Armours {get; set;}
        public DbSet<Enemy> Enemies {get; set;}
        public DbSet<Food> Foods {get; set;}
        public DbSet<Stat> Stats {get; set;}
        public DbSet<Student_Armour> Student_Armors {get; set;}
        public DbSet<Student_Food> Student_Foods {get; set;}  
        public DbSet<Student_Weapon> Student_Weapons {get; set;}  
        public DbSet<Student> Students {get; set;}
        public DbSet<Weapon> Weapons {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Student_Armour relationships
            modelBuilder.Entity<Student_Armour>()
                .HasOne(sa => sa.Student)
                .WithMany(s => s.Student_Armours)
                .HasForeignKey(sa => sa.StudentId)
                .OnDelete(DeleteBehavior.Restrict); // Or use DeleteBehavior.SetNull

            modelBuilder.Entity<Student_Armour>()
                .HasOne(sa => sa.Armour)
                .WithMany(a => a.Student_Armours)
                .HasForeignKey(sa => sa.ArmourId)
                .OnDelete(DeleteBehavior.Restrict); // Or use DeleteBehavior.SetNull

            // Configure Student's relationship with Armour
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Armour)
                .WithMany()
                .HasForeignKey(s => s.ArmourId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascade delete

                // ----------------------------------------

            // Configure Student_Weapon relationships
            modelBuilder.Entity<Student_Weapon>()
                .HasOne(sa => sa.Student)
                .WithMany(s => s.Student_Weapons)
                .HasForeignKey(sa => sa.StudentId)
                .OnDelete(DeleteBehavior.Restrict); // Or use DeleteBehavior.SetNull

            modelBuilder.Entity<Student_Weapon>()
                .HasOne(sa => sa.Weapon)
                .WithMany(a => a.Student_Weapons)
                .HasForeignKey(sa => sa.WeaponId)
                .OnDelete(DeleteBehavior.Restrict); // Or use DeleteBehavior.SetNull

            // Configure Student's relationship with Weapon
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Weapon)
                .WithMany()
                .HasForeignKey(s => s.WeaponId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid cascade delete
        }
    }
}