using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


namespace Student_game.Server.Models
{
    public class Student
    {
        // Keys
        public int Id { get; set; }

        // Key fragments
        
        [Required]
        public int Money { get; set; } = 0;
        
        [Required]
        public int Energy { get; set; } = 100;
        
        // Experience and position in ranking
        public int LevelPoints { get; set; } = 0;
        public Ranks Rank { get; set; } = Ranks.Silver_I;
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;

        // Points used in fights, events etc.
        [Required]
        public int HealthPoints { get; set; } = 100;    // bazowe zdrowie
        
        [Required]
        public int AttackPoints { get; set; } = 1;      // bazowy atak
        
        [Required]
        public int DefensePoints { get; set; } = 1;     // zwieksza procentowo hp przy ataku
        
        [Required]
        public int LuckPoints { get; set; } = 1;        // pomaga przy losowaniu do ataku

        [Required]
        public int IntelligencePoints { get; set; } = 1;// 
        
        // Equipped items
        [ForeignKey("Armour")]
        [AllowNull]
        public int? EqArmourId { get; set; }
        
        [ForeignKey("Weapon")]
        [AllowNull]
        public int? EqWeaponId { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }

        // Db relation
        public ICollection<Student_Weapon> Student_Weapons { get; set; } = new List<Student_Weapon>();
        public ICollection<Student_Armour> Student_Armours { get; set; } = new List<Student_Armour>();
        public ICollection<Student_Food> Student_Foods { get; set; } = new List<Student_Food>();
        public Stat? Stats{ get; set; }

        //child
        public Armour Armour { get; set; } = null!;
        public Weapon Weapon { get; set; } = null!;
        public Account Account { get; set; } = null!;
    }
}