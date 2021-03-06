using System;
using System.IO;
using System.Text;
using BackendCore.Common.Core;
using BackendCore.Common.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BackendCore.Common.Extensions
{
    public static class ConfigureDependencyExtension
    {
        public static IServiceCollection RegisterCommonServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors();
            services.RegisterMainCore();
            services.AddApiDocumentationServices(configuration);
            services.RegisterAuthentication(configuration);
            return services;
        }

        /// <summary>
        /// Register Main Core Dependencies
        /// </summary>
        /// <param name="services"></param>
        private static void RegisterMainCore(this IServiceCollection services)
        {
            services.AddScoped<IClaimService, ClaimService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IResponseResult, ResponseResult>();
            services.AddTransient<IFinalResult, Result>();
        }

        /// <summary>
        /// Register Authentication
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        private static void RegisterAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                };
            });
        }
        /// <summary>
        /// Register Api Swagger Documentation
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>

        private static void AddApiDocumentationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                string title = configuration["SwaggerConfig:Title"];
                string version = configuration["SwaggerConfig:Version"];
                string docPath = configuration["SwaggerConfig:DocPath"];
                options.SwaggerDoc(version, new OpenApiInfo { Title = title, Version = version });
                var filePath = Path.Combine(AppContext.BaseDirectory, docPath);
                options.IncludeXmlComments(filePath);
                var security = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }

                    }
                };
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                options.AddSecurityRequirement(security);

            });
            services.AddSwaggerGenNewtonsoftSupport();
        }
    }
}
