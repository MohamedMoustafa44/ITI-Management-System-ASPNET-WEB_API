
using ITISystem.BL;
using ITISystem.DAL;
using Microsoft.EntityFrameworkCore;

namespace ITISystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            #region Default
            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             );
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region DataBase Connection
            builder.Services.AddDbContext<ITIDbContext>(options =>
            {
                var connectionString = builder.Configuration.GetConnectionString("ITIConnectionString");
                options.UseSqlServer(connectionString);
            });
            #endregion

            #region Repos
            builder.Services.AddScoped<IStudentRepo, StudentRepo>();
            builder.Services.AddScoped<IInstructorRepo, InstructorRepo>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<ICourseRepo, CourseRepo>();
            builder.Services.AddScoped<IInstructor_CourseRepo, Instructor_CourseRepo>();
            #endregion

            #region Managers
            builder.Services.AddScoped<IStudentManager, StudentManager>();
            builder.Services.AddScoped<IInstructorManager, InstructorManager>();
            builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();
            builder.Services.AddScoped<ICourseManager, CourseManager>();
            builder.Services.AddScoped<IInstructor_CourseManager, Instructor_CourseManager>();
            #endregion

            var app = builder.Build();

            #region MiddleWares
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
            #endregion
        }
    }
}