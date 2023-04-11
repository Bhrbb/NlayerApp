using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Repository.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasData(new ProductEntity { Id = 1,Name="Kırmızı kalem", CategoryId = 1, Price = 20, Stok = 100, CreatedDate = DateTime.Now },
                new ProductEntity { Id = 2, CategoryId = 2,Name="CoksatanKitap", Price = 100, Stok = 50, CreatedDate = DateTime.Now },
                new ProductEntity { Id = 3, CategoryId = 1,Name="MickeyKalem", Price = 35, Stok = 30, CreatedDate = DateTime.Now },
                new ProductEntity { Id = 4, CategoryId = 3, Name="AjandaDefter",Price = 55, Stok = 45, CreatedDate = DateTime.Now });
        }
    }
}
