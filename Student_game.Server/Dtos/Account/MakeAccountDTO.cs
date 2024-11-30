using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Account
{
    public class MakeAccountDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public DateTime DateCreated { get; set;}
        public DateOnly Born_date { get; set; }
        public bool IsAdmin { get; set;}
    }
}