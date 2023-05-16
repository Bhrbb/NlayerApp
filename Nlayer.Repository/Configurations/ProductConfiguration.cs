using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nlayer.Core.Models;

namespace Nlayer.Repository.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(x => x.Id);
            // builder.Property(x => x.Name).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Stok).IsRequired().HasColumnType("decimal(18,2)");




        }
    }

}
