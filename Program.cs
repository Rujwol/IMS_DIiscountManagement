using DiscountManagementService.DataAccessLayer;
using DiscountManagementService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace DiscountManagementService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddSingleton(new DatabaseConnectionManager(connectionString));

            //builder.Configuration.AddJsonFile("appsettings.json");
            //builder.Services.AddSingleton<DatabaseConnectionManager>();

            builder.Services.AddTransient<IDataProcessOrchestrator, DataProcessOrchestrator>();
            builder.Services.AddTransient<IDiscountprocessor, DiscountProcesser>();


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