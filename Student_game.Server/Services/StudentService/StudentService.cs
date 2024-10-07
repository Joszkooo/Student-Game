using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Student_game.Server.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public StudentService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<Student>> GetStudentById(int id)
        {
            var serviceResponse = new ServiceResponse<Student>(); 
            try
            {
                var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id);
                if (student is not null)
                {
                    serviceResponse.Data = _mapper.Map<Student>(student);
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
    }
}