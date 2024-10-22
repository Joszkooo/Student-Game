using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Models
{
    public class Account
    {
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nickname { get; set; } = string.Empty;

        [Required, EmailAddress]
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; } = string.Empty;

        public DateTime DateCreated { get; set;} = DateTime.Now;
        
        [Required]
        public DateOnly Born_date { get; set; }

        [Required]
        public bool IsAdmin { get; set;} = false;

        // Db relation
        public Student? Student { get; set; }
    }
}