using Dapper;
using SIS.DTO;
using SIS.Entities;
using SIS.Interfaces;
using System.Data;

namespace SIS.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        //injecting DB connection class dependencies
        private readonly IDbConnection _connection;
        public DepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        //CRUD REQUESTS
        public int AddDepartment(string name)
        {
            try
            {
                var queryArguments = new
                {
                    name = name
                };
                return _connection.Execute("INSERT INTO departments (name) values (@name)", queryArguments);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500, Department repositorijoje --- ", ex);
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<DepartmentDto> GetAllDepartments()
        {
            try
            {
                return _connection.Query<DepartmentDto>("SELECT * FROM departments;");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500, Departments repositorijoje --- ", ex);
                throw new Exception(ex.Message);
            }
        }
        public DepartmentDto GetDepartment(int id)
        {
            try
            {
                return _connection.QuerySingleOrDefault<DepartmentDto>("SELECT * FROM departments WHERE id = @id;", new { id });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500, Departments repositorijoje --- ", ex);
                throw new Exception(ex.Message);
            }
        }
        public int UpdateDepartment(int id, string name)
        {
            try
            {
                var queryArguments = new
                {
                    id = id,
                    name = name
                };
                return _connection.Execute("UPDATE departments SET name=@name WHERE id = @id", queryArguments);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500 - Departments repository, UpdateDepartment", ex);
                throw new Exception(ex.Message);

            }
        }
        public int DeleteDepartment(int id)
        {
            try
            {
                return _connection.Execute("DELETE FROM departments WHERE id = @id", id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500 - Departments repository, DeleteDepartment", ex);
                throw new Exception(ex.Message);
            }
        }


        //NON CRUD REQUESTS
        public int AddLecture(int id, int lecture_id)
        {
            try
            {
                var queryArguments = new
                {
                    departments_id = id,
                    lectures_id = lecture_id
                };
                return _connection.Execute("INSERT INTO departments_lectures (departments_id, lectures_id) VALUES (@departments_id, @lectures_id");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500 - Departments repository, AddLectures", ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
