using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLayer.Core;
using NLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext : DbContext
    {
        private IConfigurationRoot configuration;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            string appSettings = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            this.configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile($"appsettings.{appSettings}.json")
                .Build();
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());// tüm asmblyi tarayıp ilgili interface i içerenleri alır

            modelBuilder.Entity<ProductFeature>().HasData(
                new ProductFeature() { Id = 1, ProductId = 1, Color = "Red", Height = 100, Width = 50 },
                new ProductFeature() { Id = 2, ProductId = 2, Color = "Blue", Height = 10, Width = 5 }
                );


            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            //optionsBuilder.UseNpgsql(configuration.GetConnectionString("Postgresql"), option => option.MigrationsAssembly("NLayer.Repository"));
            

        }

    }
}
