using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Dtos.Equipment
{
    public class StudentEquipmentDTO
    {
        public List<GetArmourDTO>? Armors { get; set; }
        public List<GetFoodDTO>? Foods { get; set; }
        public List<GetWeaponDTO>? Weapons { get; set; }
    }
}