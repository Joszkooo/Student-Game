using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.ArmourService
{
    public interface IArmourService
    {
        Task<ServiceResponse<Armour>> GetArmourById (int id);
        Task<ServiceResponse<Armour>> GetAllArmour ();
    }
}