using Microsoft.EntityFrameworkCore;
using RestaurantApp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Entities
{
    public partial class RestaurantDBContext : DbContext
    {
        ConnectionStringHelper con;

        public RestaurantDBContext(ConnectionStringHelper cs)
        {
            con = cs;
        }
    }
}
