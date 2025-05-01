
using EDU.Business.Abstract;
using EDU.Business.Concrete;
using EDU.DataAccess.Abstract;
using EDU.DataAccess.Context;
using EDU.DataAccess.Repositories;
using EDU.WebAPI.Middlewares;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EDU.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHttpsRedirection(options =>
            {
                options.HttpsPort = 7234; // Burada sənin launchSettings-dəki HTTPS port
            });
            // Add services to the container.
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            builder.Services.AddDbContext<EDUDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
            });
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
