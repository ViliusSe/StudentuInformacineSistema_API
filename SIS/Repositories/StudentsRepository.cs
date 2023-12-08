using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using SIS.Entities;
using SIS.DTO;
using SIS.Interfaces;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Xml.Linq;

namespace SIS.Repositories
{
    public class StudentsRepository : IStudentsRepository
    {
        //injecting DB connection class dependencies
        private readonly IDbConnection _connection;
        public StudentsRepository(IDbConnection npgsqlConnection)
        {
            _connection = npgsqlConnection;
        }


        //CRUD REQUESTS
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

        public IEnumerable<StudentDto> GetAll()
        {
            try
            {
                return _connection.Query<StudentDto>("Select * from students");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500, Students repositorijoje --- " + ex);
                throw;
            }
        }

        public IEnumerable<StudentDto> GetStudent(int id)
        {
            try
            {
                return _connection.Query<StudentDto>("SELECT * FROM students WHERE id = @id", id); ;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500, Students repositorijoje --- " + ex);
                throw;
            }
        }

        public int UpdateStudent(int id, string name, int department_id)
        {
            try
            {
                var queryArguments = new
                {
                    id = id,
                    departments_id = department_id,
                    name = name

                };
                return _connection.Execute("UPDATE students SET departments_id = @departments_id, name=@name WHERE id = @id", queryArguments);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500 - Students repository, AddStudent", ex);
                throw new Exception(ex.Message);
            }
        }

        public int DeleteStudent(int id)
        {
            try
            {
                return _connection.Execute("DELETE FROM students WHERE id = @id", id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500 - Students repository, AddStudent", ex);
                throw new Exception(ex.Message);
            }
        }

        //NON CRUD REQUESTS
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
