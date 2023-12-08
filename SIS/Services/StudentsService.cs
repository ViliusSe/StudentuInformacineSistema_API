using SIS.Entities;
using SIS.DTO;
using SIS.Interfaces;

namespace SIS.Services
{
    public class StudentsService : IStudentsService
    {

        //injecting Student repository dependability
        private readonly IStudentsRepository _studentsRepository;
        public StudentsService(IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
        }


        // CRUD
        public int AddStudent(string name)
        {
            return _studentsRepository.AddStudent(name);
        }

        public IEnumerable<StudentDto> GetAll()
        {
            return _studentsRepository.GetAll();
        }

        public StudentDto GetStudent(int id)
        {
            return _studentsRepository.GetStudent(id);
        }

        public int UpdateStudent(int id, string name, int department_id)
        {
            return _studentsRepository.UpdateStudent(id, name, department_id);
        }

        public int DeleteStudent(int id)
        {
            return _studentsRepository.DeleteStudent(id);
        }

        //SPECIFIC
        public int AddDepartment(int studentId, int departmentInt)
        {
            return _studentsRepository.AddDepartment(studentId, departmentInt);
        }

        public IEnumerable<Student> ShowAllStudentsAndRelations()
        {
            return _studentsRepository.ShowAllStudentsAndRelations();
        }

        public IEnumerable<LectureDto> ShowStudentLectures(int student_id)
        {
            return _studentsRepository.ShowStudentLectures(student_id);
        }
    }
}
