using SIS.DTO;
using SIS.Entities;
namespace SIS.Interfaces
{
    public interface IStudentsRepository 
    {
        public int AddStudent(string name);
        public IEnumerable<StudentDto> GetAll();
        public int AddDepartment(int id, int departments_id);
    }
}
