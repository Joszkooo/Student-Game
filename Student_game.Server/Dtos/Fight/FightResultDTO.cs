using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Fight
{
    public class FightResultDTO
    {
        public List<int> OpponentAttacks { get; set; } = new List<int>();
        public List<int> AttackerAttacks { get; set; } = new List<int>();
        public CharactersDTO Winner { get; set; } = new CharactersDTO();
        public CharactersDTO Looser { get; set; } = new CharactersDTO();
    }
}