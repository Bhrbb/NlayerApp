namespace Nlayer.Core.Models
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ProductEntity> Products { get; set; }

        //bir category de birden fazla product bulunabilir 
    }
}
