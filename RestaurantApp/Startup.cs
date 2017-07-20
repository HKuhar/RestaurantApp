using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RestaurantApp.Models;
using RestaurantApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace RestaurantApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RestaurantDBContext>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();

            //services.AddSingleton<IDishesRepository, FakeDishesRepository>();
            services.AddSingleton<IDishesRepository, EFDishesRepository>();

            services.AddSingleton<IOrdersRepository, FakeOrdersRepository>();

            //services.AddSingleton<Cart>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseSession();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMvc(routes => routes.MapRoute(name: "Default", template: "{controller=Home}/{action=Index}/{id:int?}"));

        }
    }
}
