using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Student_game.Server.Dtos.Student;



namespace Student_game.Server.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;

        public StudentService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Student>> GetStudentById(int id)
        {
            var serviceResponse = new ServiceResponse<Student>(); 
            try
            {
                var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
                if (student is not null)
                {
                    serviceResponse.Data = student;
                    return serviceResponse;
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak studenta o {id} id";
                    return serviceResponse;
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error: {ex.Message}";
                return serviceResponse;
            }
        }

        public async Task<ServiceResponse<Student>> GetStudentEquipment(int id)
        {
            var serviceResponse = new ServiceResponse<Student>();
            try
            {
                var inventory = await _context.Students
                .Include(c => c.Student_Armor)
                .Include(c => c.Student_Food)
                .Include(c => c.Student_Weapon)
                .FirstOrDefaultAsync(x => x.Id == id);
                
                if (inventory is not null)
                {
                    serviceResponse.Data = inventory;
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak ekwipunku dla studenta o {id} id";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error: {ex.Message}";
                return serviceResponse;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStudentProfileDTO>> Profile(int id)
        {
            var serviceResponse = new ServiceResponse<GetStudentProfileDTO>();
            try
            {
                var response = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
                
                if (response is not null)
                {
                    serviceResponse.Data = response.Adapt<GetStudentProfileDTO>();
                }
                else{
                    serviceResponse.Success = false;
                    serviceResponse.Message = $"Brak studenta o {id} id";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = $"Error: {ex.Message}";
                return serviceResponse;
            }
            return serviceResponse;
        }
    }
}