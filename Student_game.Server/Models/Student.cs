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
        
        [Required]
        public int LevelPoints { get; set; } = 0;
        
        // Experience and position in ranking
        public Ranks Rank { get; set; } = Ranks.Silver_I;
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;

        // Points used in fights, events etc.
        [Required]
        public int HealthPoints { get; set; } = 100;
        
        [Required]
        public int AttackPoints { get; set; } = 1;
        
        [Required]
        public int DefensePoints { get; set; } = 1;
        
        [Required]
        public int LuckPoints { get; set; } = 1;

        [Required]
        public int IntelligencePoints { get; set; } = 1;
        

        [ForeignKey("Account")]
        public int AccountId { get; set; }

        // Db relation
        public Equipment? Equipment { get; set; } = null!;
        public Stat? Stats{ get; set; } = null!;
        public Account? Account { get; set; } = null!;
    }
}