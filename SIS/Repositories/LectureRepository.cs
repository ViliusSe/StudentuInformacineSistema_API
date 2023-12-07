using Dapper;
using SIS.Interfaces;
using System.ComponentModel;
using System.Data;

namespace SIS.Repositories
{
    public class LectureRepository : ILectureRepository
    {
        private readonly IDbConnection _connection;
        public LectureRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public int AddLecture(string name)
        {
            try
            {
                var queryArguments = new
                {
                    name = name
                };
                return _connection.Execute("INSERT INTO lectures (name) VALUES (@name)", queryArguments);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500, lecture repositorijoje --- ", ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
