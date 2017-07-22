using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Infrastructure
{
    public class ConnectionStringHelper
    {
        public IConfiguration Configuration;

        private string connectionString;

        public ConnectionStringHelper(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true).Build();
            connectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        public string Get()
        {
            return connectionString;
        }
    }
}
