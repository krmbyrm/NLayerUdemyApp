﻿using Microsoft.EntityFrameworkCore;
using NLayer.Core;
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

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           // var p = new Product() { ProductFeature = new() { Color = "red" } };
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());// tüm asmblyi tarayıp ilgili interface i içerenleri alır

            modelBuilder.Entity<ProductFeature>().HasData(
                new ProductFeature() { Id=1,ProductId=1,Color="Red",Height=100,Width=50},
                new ProductFeature() { Id = 2, ProductId = 2, Color = "Blue", Height = 10, Width = 5 }
                );


            base.OnModelCreating(modelBuilder);

        }

    }
}
