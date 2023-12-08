using SIS.DTO;

namespace SIS.Interfaces
{
    public interface IDepartmentRepository
    {
        public int AddDepartment(string name);
        public IEnumerable<DepartmentDto> GetAllDepartments();
        public IEnumerable<DepartmentDto> GetDepartment(int id);
        public int UpdateDepartment(int id, string name);
        public int DeleteDepartment(int id);

        //Business Logic
        public int AddLecture(int id, int lecture_id);
    }
}

