using Microsoft.EntityFrameworkCore;
using Nlayer.Core.Models;
using Nlayer.Core.Repositories;

namespace Nlayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<CategoryEntity> GetSingleCategoryByIdWithProductsAsync(int categoryid)
        {
            return await _context.Categories.Include(x => x.Products).Where(x => x.Id == categoryid).SingleOrDefaultAsync();

        }
    }
}
