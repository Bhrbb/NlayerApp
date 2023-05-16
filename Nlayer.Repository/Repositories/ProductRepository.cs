using Microsoft.EntityFrameworkCore;
using Nlayer.Core.Models;
using Nlayer.Core.Repositories;

namespace Nlayer.Repository.Repositories
{
    public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<ProductEntity>> GetProductWithCategory()
        {
            //eager loding
            return await _context.Products.Include(x => x.Category).ToListAsync();
        }
    }
}
