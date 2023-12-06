using SIS.Interfaces;

namespace SIS.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public int AddDepartment(string name)
        {
            try
            {
                return _departmentRepository.AddDepartment(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Serverio klaida 500 - Klaida department servise --- " + ex);
                throw;
            }
        }
    }
}
