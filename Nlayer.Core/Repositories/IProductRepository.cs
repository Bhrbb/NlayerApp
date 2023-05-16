using Nlayer.Core.Models;

namespace Nlayer.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<ProductEntity>
    {
        Task<List<ProductEntity>> GetProductWithCategory();




    }
}
