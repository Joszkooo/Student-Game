using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Equipment
{
    public class GetEquipmentServiceDTO
    {
        public int StudentID { get; set; }    
        public int ItemID { get; set; }    
    }
}