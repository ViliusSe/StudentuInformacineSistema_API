using SIS.DTO;
using SIS.Entities;
namespace SIS.Interfaces
{
    public interface IStudentsRepository
    {
        public int AddStudent(string name);
        public IEnumerable<StudentDto> GetAll();
        public StudentDto GetStudent(int id);
        public int UpdateStudent(int id, string name, int department_id);
        public int DeleteStudent(int id);
        public int AddDepartment(int id, int departments_id);
        public IEnumerable<Student> ShowAllStudentsAndRelations();
    }
}
