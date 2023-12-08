using SIS.DTO;
using SIS.Interfaces;
using SIS.Repositories;

namespace SIS.Services
{
    public class LectureService : ILectureService
    {
        //injecting Lecture repository dependability
        private readonly ILectureRepository _repository;
        public LectureService(ILectureRepository repository)
        {
            _repository = repository;
        }


        // CRUD
        public int AddLecture(string name)
        {
            return _repository.AddLecture(name);
        }
        public IEnumerable<LectureDto> GetAllLectures()
        {
            return _repository.GetAllLectures();
        }
        public IEnumerable<LectureDto> GetLecture(int id)
        {
            return _repository.GetLecture(id);
        }
        public int UpdateLecture(int id, string name)
        {
            return _repository.UpdateLecture(id, name);
        }
        public int DeleteLecture(int id)
        {
            return _repository.DeleteLecture(id);
        }


        //SPECIFIC
        public int AddDepartment(int id, int departments_id)
        {
            return _repository.AddDepartment(id, departments_id);
        }
        public int AddStudent(int id, int students_id)
        {
            return _repository.AddStudent(id, students_id);
        }
    }
}
