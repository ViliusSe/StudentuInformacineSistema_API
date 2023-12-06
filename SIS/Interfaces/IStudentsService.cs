using SIS.Entities;

namespace SIS.Interfaces
{
    public interface IStudentsService
    {
        public IEnumerable<Student> GetAll();
    }
}
