using Nlayer.Core.Dtos;
using Nlayer.Core.Models;

namespace Nlayer.Core.Services
{
    public interface IProductService : IService<ProductEntity>
    {

        Task<CustomResponseDto<List<ProductWithCategory>>> GetProductWithCategory();




    }
}
