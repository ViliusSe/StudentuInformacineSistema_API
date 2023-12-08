using SIS.DTO;

namespace SIS.Interfaces
{
    public interface ILectureService
    {
        public int AddLecture(string name);
        public IEnumerable<LectureDto> GetAllLectures();
        public IEnumerable<LectureDto> GetLecture(int id);
        public int UpdateLecture(int id, string name);
        public int DeleteLecture(int id);

        //Business Logic
        public int AddDepartment(int id, int departments_id);
        public int AddStudent(int id, int students_id);
    }
}
