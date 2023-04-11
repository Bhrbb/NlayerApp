using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core.Models
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public int Stok { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        //her productın bir categorysı oldugunu düşünelim 
        public CategoryEntity Category { get; set; }
        public ProductFeature? ProductFeature { get; set; }

    }
}
