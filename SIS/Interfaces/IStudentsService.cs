using SIS.DTO;
using SIS.Entities;

namespace SIS.Interfaces
{
    public interface IStudentsService
    {
        public int AddStudent(string name);

        public IEnumerable<StudentDto> GetAll();

        public int AddDepartment(int id, int departments_id);
    }
}
