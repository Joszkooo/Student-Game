using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Account, GetAccountDTO>();
            CreateMap<Stat, GetStatDTO>();
            // CreateMap<Weapon, GetWeaponDTO>();
        }
    }
}