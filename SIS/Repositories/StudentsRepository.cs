using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using SIS.Entities;
using SIS.DTO;
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

        public IEnumerable<StudentDto> GetAll()
        {
            try
            {
                return _connection.Query<StudentDto>("Select * from students");
            }catch (Exception ex) {
                Console.WriteLine("Klaida 500, Students repositorijoje --- " + ex);
                throw;
            }
        }
        public int AddStudent(string name)
        {
            try
            {
                var queryArguments = new
                {
                    name = name
                };
                return _connection.Execute("INSERT INTO students (name) VALUES (@name)", queryArguments);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500 - Students repository, AddStudent", ex);
                throw new Exception(ex.Message);
            }
        }

        public int AddDepartment(int id, int departments_id)
        {
            try
            {
                var queryArguments = new
                {
                    departments_id = departments_id,
                    id = id
                };
                return _connection.Execute("UPDATE students SET departments_id = @departments_id WHERE id = @id", queryArguments);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500 - Students repository, AddStudent", ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
