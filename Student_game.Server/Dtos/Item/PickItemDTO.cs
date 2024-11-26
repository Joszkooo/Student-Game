using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Item
{
    public class PickItemDTO
    {
        public int ItemId { get; set; }
        public int StudentId { get; set; }
        public CategoryDTO Category { get; set; }
    }
}