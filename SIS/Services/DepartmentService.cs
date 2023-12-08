using SIS.DTO;
using SIS.Interfaces;

namespace SIS.Services
{
    public class DepartmentService : IDepartmentService
    {
        //injecting Lecture repository dependability
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }


        // CRUD
        public int AddDepartment(string name)
        {
            return _departmentRepository.AddDepartment(name);
        }
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            return _departmentRepository.GetAllDepartments();
        }

        public IEnumerable<DepartmentDto> GetDepartment(int id)
        {
            return _departmentRepository.GetDepartment(id);
        }

        public int UpdateDepartment(int id, string name)
        {
            return _departmentRepository.UpdateDepartment(id, name);
        }
        public int DeleteDepartment(int id)
        {
            return (_departmentRepository.DeleteDepartment(id));
        }



        //SPECIFIC
        public int AddLecture(int id, int lecture_id)
        {
            return _departmentRepository.AddLecture(id, lecture_id);
        }
    }
}
