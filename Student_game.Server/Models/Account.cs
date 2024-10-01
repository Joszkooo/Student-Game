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
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Nickname { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public DateOnly Born_date { get; set; }

        // Db relation
        public Student? Student { get; set; } = null!;
    }
}