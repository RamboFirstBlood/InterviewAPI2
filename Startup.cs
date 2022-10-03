using InterviewAPI2.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InterviewAPI2.Repository;
using AutoMapper;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace InterviewAPI2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<BookDBContext>(options =>
                     options.UseSqlServer(Configuration.GetConnectionString("myconn")));
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddLogging(loggingBuilder => loggingBuilder
            .AddConsole()
            .AddDebug()
            .SetMinimumLevel(LogLevel.Debug));
            services.AddSwaggerGen();
            services.AddFluentValidationRulesToSwagger();
            services.AddHealthChecks()
                .AddCheck("BookDBCheck", new SqlConnectionHealthCheck(Configuration.GetConnectionString("myconn")),
                HealthStatus.Unhealthy,
                new string[] { "BookDB" });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/hc");
            });
        }
    }
}
