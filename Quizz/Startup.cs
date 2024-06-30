using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Quizz.Common.Configuration;
using Quizz.Domain.Core;
using Quizz.Domain.Core.Entities;
using Quizz.Domain.Infrastructure;
using Quizz.Domain.Infrastructure.Data;
using Quizz.Domain.Infrastructure.Data.Mapping;
using Serilog;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace Quizz
{
    public class Startup
    {

        public IConfigurationRoot Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        private readonly bool isDebugEnvironment;

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
               .AddJsonFile("appsettings.Secrets.json", optional: true, reloadOnChange: true)
               .AddEnvironmentVariables();
            isDebugEnvironment = env.IsDevelopment();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly("Quizz.Domain.Infrastructure"));
            });

            string[] origin = Configuration.GetSection("CustomSettings:Origin").GetChildren().Select(c => c.Value).ToArray();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddLogging();
            services.Configure<JWT>(Configuration.GetSection("JWT"));
            var jwt = Configuration.GetSection("JWT").Get<JWT>();


            services.AddControllers();
            // Configure JWT authentication
            var keyBytes = Encoding.ASCII.GetBytes(jwt.JwtSecret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddMvc()
                .AddMvcOptions(i => i.EnableEndpointRouting = false).AddXmlSerializerFormatters();

            services.AddAutoMapper(cfg =>
            {
                cfg.DisableConstructorMapping();
                cfg.AddProfile(new InfraDataProfile());

            }, AppDomain.CurrentDomain.GetAssemblies());
            //Culture information
            CultureConfiguration cultureConfig = Configuration.GetSection(ConfigurationStrings.Sections.CultureInfoConfiguration).Get<CultureConfiguration>();
            services.AddSingleton(cultureConfig);

            //Mailing service
            MailConfiguration emailConfig = Configuration.GetSection(ConfigurationStrings.Sections.EmailConfiguration).Get<MailConfiguration>();
            services.AddSingleton(emailConfig);

            SwaggerConfig();

            #region local methods

            void SwaggerConfig()
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Boilerplate Api", Version = "v1" });
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Name = "Authorization",
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer",
                        BearerFormat = "JWT",
                        In = ParameterLocation.Header,
                        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer abcdefgh12345\"",
                    });
                    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                            Array.Empty<string>()
                         }
                     });
                });
            }
            #endregion
        }

        /// <summary>
        /// Ajout des modules
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var jwt = Configuration.GetSection("JWT").Get<JWT>();

            builder.RegisterModule(new QuizzDomainCoreModule(jwt.JwtSecret));
            builder.RegisterModule(new QuizzDomainInfrastructureModule());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSerilogRequestLogging();
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            //if (env.IsDevelopment())
            //{
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(Configuration.GetSection(ConfigurationStrings.Sections.SwaggerConfiguration).GetValue<string>(ConfigurationStrings.SwaggerConfigurationElements.JsonPath), "Api V1");

                });
                app.UseDeveloperExceptionPage();
            //}

            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
        }
    }
}
