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

        // get full info about student
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

        // get eq of student
        public async Task<ServiceResponse<Student>> GetStudentEquipment(int id)
        {
            throw new NotImplementedException();
            // var serviceResponse = new ServiceResponse<Dictionary<int, Object>>();
            // try
            // {
            //     var inventory = await _context.Students
            //         .Include(s => s.Student_Armor)
            //             .ThenInclude(sa => sa.Armour)
            //         .Include(sf => sf.Student_Food)
            //             .ThenInclude(s => s.Food)
            //         .Include(sw => sw.Student_Weapon)
            //             .ThenInclude(s => s.Weapon)
            //         .FirstOrDefaultAsync(x => x.Id == id);

            //     if (inventory is not null)
            //     {
            //         serviceResponse.Data = serviceResponse.Add;
            //     }
            //     else{
            //         serviceResponse.Success = false;
            //         serviceResponse.Message = $"Brak ekwipunku dla studenta o {id} id";
            //     }
            // }
            // catch (Exception ex)
            // {
            //     serviceResponse.Success = false;
            //     serviceResponse.Message = $"Error: {ex.Message}";
            //     return serviceResponse;
            // }
            // return serviceResponse;
        }

        // get student info for profile page 
        public async Task<ServiceResponse<GetStudentProfileDTO>> GetStudentProfile(int id)
        {
            var serviceResponse = new ServiceResponse<GetStudentProfileDTO>();
            try
            {
                var student = await _context.Students
                    .Include(c => c.Account)
                        .FirstOrDefaultAsync(x => x.Id == id);
                
                if (student is not null)
                {
                    GetStudentProfileDTO response = student.Adapt<GetStudentProfileDTO>(); 
                    response.Nickname = student.Account.Nickname;
                    
                    serviceResponse.Data = response;
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