using Nlayer.Core.Models;

namespace Nlayer.Core.Dtos
{
    public class ProductFeatureDto
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        //birebir ilişki
        public int ProductId { get; set; }
        public CategoryEntity Category { get; set; }

    }
}
