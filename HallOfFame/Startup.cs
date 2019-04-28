using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HallOfFame.FileLogger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HallOfFame
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDatabaseContext>(o => o.UseSqlServer("Data Source=LAPTOP-SVCPQ4K6\\SQLEXPRESS;Initial Catalog=DbHallOfFame;Integrated Security=True"));
            services.AddMvc();
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My First Swagger" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(),"logger.txt"));
        var logger = loggerFactory.CreateLogger("FileLogger");
         
        app.Run(async (context) =>
        {
            logger.LogInformation("Processing request {0}", context.Request.Path);
            await context.Response.WriteAsync("Hall of Fame!");
        });
        }
    }
}
