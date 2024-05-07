using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Quizz.Common.Configuration;
using Quizz.Domain.Core;
using Quizz.Domain.Infrastructure;
using Quizz.Domain.Infrastructure.Data;
using Quizz.Domain.Infrastructure.Data.Mapping;

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
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
               .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
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

            services.AddControllers();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Latest)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>())
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
            builder.RegisterModule(new QuizzDomainCoreModule());
            builder.RegisterModule(new FolderDomainInfrastructureModule());

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Presenter")).SingleInstance();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSerilogRequestLogging();
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(Configuration.GetSection(ConfigurationStrings.Sections.SwaggerConfiguration).GetValue<string>(ConfigurationStrings.SwaggerConfigurationElements.JsonPath), "Api V1");

            });

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
        }
    }
}
