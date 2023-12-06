using SIS.Entities;

namespace SIS.Interfaces
{
    public interface IStudentsRepository 
    {
        public IEnumerable<Student> GetAll();
    }
}
