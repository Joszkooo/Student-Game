using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Identity;

namespace Student_game.Server.Models
{
    public class Account: IdentityUser<int>
    {
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Nickname { get; set; } = string.Empty;

        public DateTime DateCreated { get; set;} = DateTime.Now;
        
        [Required]
        public DateOnly Born_date { get; set; }

        [Required]
        public bool IsAdmin { get; set;} = false;

        // Db relation
        // public Student? Student { get; set; }
    }
}