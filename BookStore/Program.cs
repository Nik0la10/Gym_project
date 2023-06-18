using FluentValidation;
using FluentValidation.AspNetCore;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using Gym.Healthchecks;
using Gym.Extensions;
using Gym.BL.Services;
using Gym.Models.Configs;
using Gym.DL.Interfaces;
using Gym.DL.Repository.Mongo;
using Gym.BL.Interfaces;

namespace Gym
{
    public class Program
    {
        public static void Main(string[] args)
        {


            var logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .WriteTo.File(path: "log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.AddSerilog(logger);

            // Add configurations.
            builder.Services.Configure<MongoConfiguration>(
                builder.Configuration.GetSection(nameof(MongoConfiguration)));
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            // Add services to the container.

            builder.Services
                .AddSingleton<IManufacturerRepository, ManufacturerRepository>();
            builder.Services
                .AddSingleton<IManufacturerService, ManufacturerService>();

            builder.Services
                .AddSingleton<IProductRepository, ProductRepository>();
            builder.Services
                .AddSingleton<IProductService, ProductService>();

            builder.Services
                .AddSingleton<IListService, ListService>();

            builder.Services.AddAutoMapper(
                typeof(Program));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
            builder.Services
                .AddValidatorsFromAssemblyContaining(typeof(Program));

            builder.Services.AddHealthChecks()
                .AddCheck<MongoHealthCheck>("MongoDB")
                .AddUrlGroup(
                    new Uri("https://google.bg"), "My Service");

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.RegisterHealthCheck();


            app.MapControllers();

            app.Run();
        }
    }
}