using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_game.Server.Services.StudentService
{
    public interface IStudentService
    {
        Task<ServiceResponse<Student>> GetStudentById(int id);
        Task<ServiceResponse<Student>> GetStudentEquipment(int id);
    }
}