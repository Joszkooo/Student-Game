using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.FightService
{
    public interface IFightService
    {
        /*
        We will have two types of fights:
        1. npc-player fight (player will fight with enemy from Enemy table in db)
        2. player-player fight (not sure if it will be implemented)

        1. First off we need to get RandomEnemy from EnemyController, then calculate his attack and then apply hit chance on every attack, luck points etc
        Then same with us.
        At the end we will calculate in loop every attack from both sides and pass them in the array.
        We will pass that array and winner to the data. ende

        */
        
        Task<ServiceResponse<FightResultDTO>> FightLocally(FightCharactersDTO characters); // <- all implementation goes here, it is passed to the frontend
        Task<ServiceResponse<FightResultDTO>> FightOnline(FightCharactersDTO characters); // <- all implementation goes here, it is passed to the frontend
    }
}