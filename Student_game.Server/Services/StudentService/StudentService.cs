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

        public async Task<ServiceResponse<Student>> GetStudent(int id)
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
                    serviceResponse.Message = $"Brak studenta o określonym id";
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
    }
}