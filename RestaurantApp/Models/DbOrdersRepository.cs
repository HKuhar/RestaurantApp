using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.Models
{
    public class DbOrdersRepository : IOrdersRepository
    {
        string cs;
        SqlConnection con;
        int nextId;
        IConfigurationRoot Configuration;

        public DbOrdersRepository(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true).Build();
            cs = Configuration.GetConnectionString("DefaultConnection");
            con = new SqlConnection(cs);

            SqlCommand cmd = new SqlCommand("SELECT MAX(OrderId) FROM dbo.Orders", con);
            con.Open();
            string temp = cmd.ExecuteScalar().ToString();
            if (temp == "")
            {
                nextId = 1;
            }
            else
            {
                nextId = Int32.Parse(temp) + 1;
            }
            con.Close();
        }

        public void AddOrder(Order o)
        {
            o.OrderId = nextId;
            string sqlFormattedDate = o.Time.ToString("s");
            SqlCommand cmd = new SqlCommand($"INSERT INTO dbo.Orders VALUES ({o.OrderId}, '{o.Name}', '{o.Street}', {o.Number}, '{sqlFormattedDate}')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            foreach (var item in o.Cart.cartItems)
            {
                SqlCommand command = new SqlCommand($"INSERT INTO dbo.OrderItems (Name, Quantity, OrderId) VALUES ('{item.Dish.Name}', {item.Quantity}, {o.OrderId})", con);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            nextId++;
        }

        public ICollection<Order> GetOrders()
        {
            ICollection<Order> returnCollection = new List<Order>();

            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Orders", con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();     

            while (reader.Read())
            {
                Cart cartToInsert = new Cart();
                

                SqlCommand cmdB = new SqlCommand($"SELECT * FROM dbo.OrderItems WHERE OrderId = {reader.GetInt32(0)}", con);
                SqlDataReader readerB = cmdB.ExecuteReader();

                while (readerB.Read())
                {
                    cartToInsert.cartItems.Add(new CartItem { Quantity = readerB.GetInt32(2), Dish = new Entities.Dishes { Name = readerB.GetString(1) } });
                }

                Order orderToInsert = new Order { OrderId = reader.GetInt32(0), Name = reader.GetString(1), Street = reader.GetString(2), Number = reader.GetInt32(3), Time = reader.GetDateTime(4), Cart = cartToInsert };
                returnCollection.Add(orderToInsert);
            }

            con.Close();

            return returnCollection;
        }
    }
}
