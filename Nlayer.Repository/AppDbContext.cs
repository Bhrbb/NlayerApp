using Microsoft.EntityFrameworkCore;
using Nlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
        {

        }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
         public DbSet<ProductFeature> ProductFeatures { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature()
            //{
            //    Id = 1,
            //    Color = "Kırmızı",
            //    Height = 20,
            //    Width = 20,
            //    ProductId = 1
            //}, new ProductFeature()
            //{
            //    Id = 2,
            //    Color = "Mavi",
            //    Height = 20,
            //    Width = 20,
            //    ProductId = 2
            //});

            base.OnModelCreating(modelBuilder);

          
        }
    }
}
