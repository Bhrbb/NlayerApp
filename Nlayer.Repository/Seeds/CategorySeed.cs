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
    public class CategorySeed : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasData(new CategoryEntity() { Id = 1, Name = "Kalem" },
                new CategoryEntity { Id = 2, Name = "Kitap" },
                new CategoryEntity { Id = 3, Name="Defter" });
        }
    }
}
