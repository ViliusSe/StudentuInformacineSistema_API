using SIS.Entities;
using SIS.Interfaces;

namespace SIS.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository _studentsService;
        public StudentsService(IStudentsRepository studentsRepository) {
            _studentsService = studentsRepository;
        }

        public IEnumerable<Student> GetAll()
        {
           try
            {
                return _studentsService.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Serverio klaida 500 - Klaida renkant Studentu duomenis --- " + ex);
                throw ex;
            }
        }
    }
}
