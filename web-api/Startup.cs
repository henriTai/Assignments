using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using web_api.Controllers;
using web_api.Models;
using web_api.Middleware;
using web_api.ErrorHandling;

namespace web_api
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
            IRepository i = new InMemoryRepository();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton(i);
            services.AddSingleton(new PlayersProcessor(i)); //geneerisellä metodilla <>
            services.AddSingleton(new ItemsProcessor(i));         
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseGlobalErrorHandler();//web_api.Middleware
            //app.UseMiddleware(typeof(GlobalErrorHandler));
            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute("items", "Players/{id}/{controller = Items}");
                routes.MapRoute("default", "{controller=Players}/{action=Index}/{id?}");
            });
        }
    }
}
