using SIS.Interfaces;
using SIS.Repositories;

namespace SIS.Services
{
    public class LectureService : ILectureService

    {
        private readonly ILectureRepository _repository;

        public LectureService(ILectureRepository repository)
        {
            _repository = repository;
        }

        public int AddLecture(string name)
        {
            try
            {
                return _repository.AddLecture(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Serverio klaida 500 - Klaida lecture servise --- " + ex);
                throw;
            }
        }
    }
}
