using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace RestaurantApp.Entities
{
    public partial class RestaurantDBContext : DbContext
    {
        public IConfigurationRoot Configuration;

        private string connectionString;

        public RestaurantDBContext(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json").AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true).Build();
            connectionString = Configuration.GetConnectionString("DefaultConnection");
        }

        public virtual DbSet<Dishes> Dishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dishes>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnType("varchar(max)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Price).HasColumnType("decimal");
            });
        }
    }
}