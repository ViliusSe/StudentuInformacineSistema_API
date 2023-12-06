
using DbUp;
using Npgsql;
using SIS.Interfaces;
using SIS.Repositories;
using SIS.Services;
using System.Data;
using System.Reflection;

namespace SIS
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(builder.Configuration.GetConnectionString("PostgreConnection")));

            builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
            builder.Services.AddScoped<IStudentsService, StudentsService>();

            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();


            /* 
            * MIGRATION START
            */

            //var configuration = new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory())
            //.AddJsonFile("appsettings.json")
            //.Build();

            //var upgrader = DeployChanges.To
            //    .PostgresqlDatabase(dbConnectionString)
            //    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
            //    .LogToConsole()
            //    .Build();

            //var result = upgrader.PerformUpgrade();

            //if (!result.Successful)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine(result.Error);
            //    Console.ResetColor();
            //}
            //else
            //{
            //    Console.ForegroundColor = ConsoleColor.Green;
            //    Console.WriteLine("Success!");
            //    Console.ResetColor();
            //}

            /*
             * MIGRATION END
             */

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
