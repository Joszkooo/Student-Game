using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.WeaponService
{
    public interface IWeaponService
    {
        Task<ServiceResponse<Weapon>> GetWeaponById(int id);
        Task<ServiceResponse<List<Weapon>>> GetAllWeapon ();
    }
}