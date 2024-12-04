using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Student_game.Server.Dtos.Student;

namespace Student_game.Server.Services.StudentService
{
    public interface IStudentService
    {
        Task<ServiceResponse<Student>> GetStudentById(int StudentId);
        Task<ServiceResponse<GetStudentProfileDTO>> GetStudentProfile(int StudentId);
        Task<ServiceResponse<List<GetWeaponDTO>>> GetStudentWeapon(int StudentId);
        Task<ServiceResponse<List<GetArmourDTO>>> GetStudentArmour(int StudentId);
        Task<ServiceResponse<List<GetFoodDTO>>> GetStudentFood(int StudentId);
        ServiceResponse<StudentEquipmentDTO> GetStudentEquipment(int StudentId);
    }
}