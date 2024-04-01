using Microsoft.EntityFrameworkCore;
using PracticeAPIStudent.Data;

namespace PracticeAPIStudent
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            
            //var configuration = builder.Configuration;
            //string connection_string = configuration.GetConnectionString("postgresql://username:root123@localhost:5432/StudentInfo\r\n");
            //builder.Services.AddDbContext<ApiContext>(opt => opt.UseSqlServer(connection_string));

            builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("StudentInfo"));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
