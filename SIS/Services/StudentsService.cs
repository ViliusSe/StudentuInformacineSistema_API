using SIS.Entities;
using SIS.DTO;
using SIS.Interfaces;

namespace SIS.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository _studentsRepository;
        public StudentsService(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }

        public int AddDepartment(int studentId, int departmentInt)
        {
                return _studentsRepository.AddDepartment(studentId, departmentInt);
        }

        public int AddStudent(string name)
        {
            try
            {
                return _studentsRepository.AddStudent(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Serverio klaida 500 - klaida sutdentService AddStudent metode --- " + ex.ToString());
                throw ex;
            }
        }

        public IEnumerable<StudentDto> GetAll()
        {
            try
            {
                return _studentsRepository.GetAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Serverio klaida 500 - Klaida renkant Studentu duomenis --- " + ex);
                throw ex;
            }
        }
    }
}
