namespace AspNetCoreToDo.Web
{
    using System.Reflection;
    using AspNetCoreToDo.Web.Models;
    using AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=.\SQLEXPRESS2014;Database=AspNetCoreToDo;Trusted_Connection=True;";
            services.AddDbContext<ToDoContext>(options => options.UseSqlServer(connection));

            services.AddSession();
            services.AddMvc();
            services.AddAutoMapper(GetExecutingAssembly());
            services.AddMediatR(GetExecutingAssembly());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private static Assembly GetExecutingAssembly()
        {
            return typeof(Startup).GetTypeInfo().Assembly;
        }
    }
}
