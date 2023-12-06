using Dapper;
using SIS.Entities;
using SIS.Interfaces;
using System.Data;
using System.Data.Common;

namespace SIS.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        private readonly IDbConnection _connection;
        public StudentsRepository(IDbConnection npgsqlConnection)
        {
            _connection = npgsqlConnection;
        }

        public IEnumerable<Student> GetAll()
        {
            try
            {
                return _connection.Query<Student>("Select * from students");
            }catch (Exception ex) {
                Console.WriteLine("Klaida 500, Students repositorijoje --- " + ex);
                throw;
            }
        }
    }
}
