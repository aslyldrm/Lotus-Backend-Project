using Azure.Storage.Blobs;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Presentation.ActionFilters;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;
using Services.Contracts.Categories;
using Services.Contracts.Features;
using Services.Features;
using SixLabors.ImageSharp;
using System.Runtime.CompilerServices;
using System.Text;
using WebApi.Utilities.AzureBlobForProduct;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        =>

            services.AddDbContext<RepositoryContext>(options =>
     options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));


        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();


        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();


        public static void ConfigureLoggerService(this IServiceCollection  services) =>
               services.AddSingleton<ILoggerService, LoggerManager>();


        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationAttributeFilter>(); // IOC registration
            services.AddSingleton<LogFilterAttribute>();

        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<User, IdentityRole>(
                options =>
                {
                   // options.Password.RequireDigit = true;
                    //options.Password.RequireLowercase = true;
                    //options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 6;
                    options.User.RequireUniqueEmail = true;
                   
                })
                
                   .AddEntityFrameworkStores<RepositoryContext>()
                   .AddDefaultTokenProviders();
        }



        public static void ConfigureJWT(this IServiceCollection services,
            IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["secretKey"];

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = jwtSettings["validIssuer"],
                     ValidAudience = jwtSettings["validAudience"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                 }
            );
            

        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination")
                );
            });
        }


        public static void ConfigureServicesForEmail(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddTransient<IEmailSender, EmailSender>();

           

        }

        public static void ConfigureBlob(this IServiceCollection services,IConfiguration configuration)
        {



            string podcastConnectionString = configuration.GetValue<string>("BlobStorageForPodcast:ConnectionString");
            services.AddSingleton<BlobServiceClient>(provider => new BlobServiceClient(podcastConnectionString));
            services.AddScoped<BlobService>();

            string productBlobStorage = configuration.GetValue<string>("ProductPictureAzureBlobStorage:ConnectionString");
            services.AddSingleton(provider =>
            {
                var blobServiceClient = new BlobServiceClient(productBlobStorage);
                return new ProductPictureBlobStorageService(blobServiceClient);
            });

            string userPregnantPictures = configuration.GetValue<string>("UserPregnantPictures:ConnectionString");
            services.AddSingleton(provider =>
            {
                var blobServiceClient = new BlobServiceClient(userPregnantPictures);
                return new AzureBlobForPregnancyPictures(blobServiceClient);
            });

           



        }


    }
}
