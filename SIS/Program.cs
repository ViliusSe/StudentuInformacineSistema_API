
using DbUp;
using Npgsql;
using Serilog;
using SIS.Interfaces;
using SIS.Repositories;
using SIS.Services;
using System.Data;
using System.Reflection;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(builder.Configuration.GetConnectionString("PostgreConnection")));


/* 
*  Adding Requests
*/
builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
builder.Services.AddScoped<IStudentsService, StudentsService>();

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<ILectureRepository, LectureRepository>();
builder.Services.AddScoped<ILectureService, LectureService>();


// Creating connection shortcut
string dbConnectionString = builder.Configuration.GetConnectionString("PostgreConnection");

/* 
* MIGRATION START   DBUP
*/
EnsureDatabase.For.PostgresqlDatabase(dbConnectionString);
var upgrader = DeployChanges.To
.PostgresqlDatabase(dbConnectionString)
.WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
.LogToConsole()
.Build();

var result = upgrader.PerformUpgrade();

/*
 * ALTERNATIVE DBUP CODE
 */

//if (!result.Successful)
//{
//    Console.ForegroundColor = ConsoleColor.Red;
//    Console.WriteLine(result.Error);
//    Console.ResetColor();
//    Console.ReadLine();
//    return -1;
//}

//Console.ForegroundColor = ConsoleColor.Green;
//Console.WriteLine("Success!");
//Console.ResetColor();
//return 0;

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

/*
 * ADDING LOGGING - SERILOG
 */
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
/* END LOGGING */


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