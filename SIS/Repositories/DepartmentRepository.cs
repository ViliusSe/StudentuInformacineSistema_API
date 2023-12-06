using Dapper;
using SIS.Entities;
using SIS.Interfaces;
using System.Data;

namespace SIS.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly IDbConnection _connection;

        public DepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public int AddDepartment(string name)
        {
            try
            {
                var queryArguments = new
                {
                    name = name
                };

                return _connection.Execute("INSERT INTO departments (name) values (@name)", queryArguments);
            } catch (Exception ex)
            {
                Console.WriteLine("Klaida 500, department repositorijoje --- ", ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
