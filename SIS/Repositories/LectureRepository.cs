using Dapper;
using SIS.DTO;
using SIS.Interfaces;
using System.Data;

namespace SIS.Repositories
{
    public class LectureRepository : ILectureRepository
    {
        //injecting DB connection class dependencies
        private readonly IDbConnection _connection;
        public LectureRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        //CRUD REQUESTS
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

        public IEnumerable<LectureDto> GetAllLectures()
        {
            try
            {
                return _connection.Query<LectureDto>("Select * from lectures");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500, Lectures repositorijoje --- " + ex);
                throw;
            }
        }

        public IEnumerable<LectureDto> GetLecture(int id)
        {
            try
            {
                return _connection.Query<LectureDto>("Select * from lectures WHERE id = @id", id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500, Lectures repositorijoje --- " + ex);
                throw;
            }
        }

        public int UpdateLecture(int id, string name)
        {
            try
            {
                var queryArguments = new
                {
                    id = id,
                    name = name

                };
                return _connection.Execute("UPDATE lectures SET name=@name WHERE id = @id", queryArguments);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500 - Lectures repository, UpdateLecture", ex);
                throw new Exception(ex.Message);

            }
        }
        public int DeleteLecture(int id)
        {
            try
            {
                return _connection.Execute("DELETE FROM lectures WHERE id = @id", id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500 - Lectures repository, DeleteLecture", ex);
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
                    lectures_id = id,
                    departments_id = departments_id

                };
                return _connection.Execute("INSERT INTO departments_lectures (departments_id, lectures_id) VALUES (@departments_id, @lectures_id)", queryArguments);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500 - Lectures repository, AddDepartment", ex);
                throw new Exception(ex.Message);
            }
        }
        public int AddStudent(int id, int students_id)
        {
            try
            {
                var queryArguments = new
                {
                    lectures_id = id,
                    students_id = students_id

                };
                return _connection.Execute("INSERT INTO students_lectures (students_id, lectures_id) VALUES (@students_id, @lectures_id)", queryArguments);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida 500 - Lectures repository, AddStudent", ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
