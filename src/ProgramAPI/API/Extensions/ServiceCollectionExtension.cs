using Application.Contracts;
using Application.Services;
using Domain.Config;
using Infrastructure.Contracts;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

using Serilog;
using System.Text.Json.Serialization;

namespace API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(opts =>
            {
                opts.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
        }


        /// <summary>
        /// Register the Logger (Serilog)
        /// </summary>
        /// <param name="builder">The WebApplicationBuilder that extends this method.</param>
        /// <returns><c>Void</c></returns>
        public static void RegisterLogger(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.WriteTo.Console().ReadFrom.Configuration(context.Configuration));
        }



        /// <summary>
        /// Register IO Objects
        /// </summary>
        /// <param name="builder">The WebApplicationBuilder that extends this method.</param>
        /// <returns><c>Void</c></returns>
        public static void ConfigureIOObjects(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AzureCosmos>(configuration.GetSection(nameof(AzureCosmos)));

        }


        /// <param name="databaseName"></param>
        /// <param name="containers"></param>
        /// <returns></returns>
        public static IServiceCollection AddCosmosDb(this IServiceCollection services, IConfiguration configuration) {
            string? accountKey = configuration.GetSection("AzureCosmos")["AccountKey"];
            string? accountEndpoint = configuration.GetSection("AzureCosmos")["AccountEndpoint"];
            Microsoft.Azure.Cosmos.CosmosClient client = new Microsoft.Azure.Cosmos.CosmosClient(accountEndpoint, accountKey);
            return  services.AddSingleton(typeof(ICosmosDbRepository<>), typeof(CosmosDbRepository<>));
        }



        /// <summary>
        /// Configure RepositoryManager
        /// </summary>
        /// <param name="services">The IServiceCollection that extends this method.</param>
        /// <returns><c>void</c></returns>

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
                                           services.AddScoped<IRepositoryManager, RepositoryManager>();

        /// <summary>
        /// Configure ServiceManager
        /// </summary>
        /// <param name="services">The IServiceCollection that extends this method.</param>
        /// <returns><c>void</c></returns>
        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        /// <summary>
        /// Configure Controlers
        /// </summary>
        /// <param name="services">The IServiceCollection that extends this method.</param>
        /// <returns><c>void</c></returns>
        public static void ConfigureControllers(this IServiceCollection serviceCollection) =>
       serviceCollection.AddControllers()
                       .AddXmlDataContractSerializerFormatters()
                       .AddJsonOptions(x =>
                       {
                           // serialize enums as strings in api responses (e.g. Role)
                           x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                           x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                       }
                       );

        /// <summary>
        /// Configure API Versioning
        /// </summary>
        /// <param name="services">The IServiceCollection that extends this method.</param>
        /// <returns><c>void</c></returns>
        public static void ConfigureApiVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = new ApiVersion(1, 0);
            });
            services.AddMvcCore().AddApiExplorer();

        }
    }
}