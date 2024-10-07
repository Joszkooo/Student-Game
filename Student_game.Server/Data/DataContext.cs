using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {}
        public DbSet<Student> Students {get; set;}
        public DbSet<Account> Accounts {get; set;}
        public DbSet<Food> Foods {get; set;}
        public DbSet<Weapon> Weapons {get; set;}
        public DbSet<Armour> Armours {get; set;}
        public DbSet<Enemy> Enemies {get; set;}
        public DbSet<Stat> Stats {get; set;}
        public DbSet<Student_Armor> Student_Armors {get; set;}
        public DbSet<Student_Food> Student_Foods {get; set;}  
        public DbSet<Student_Weapon> Student_Weapons {get; set;}  
    }
}