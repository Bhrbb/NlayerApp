using Nlayer.Core.Models;

namespace Nlayer.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<CategoryEntity>
    {
        Task<CategoryEntity> GetSingleCategoryByIdWithProductsAsync(int categoryid);

    }
}
