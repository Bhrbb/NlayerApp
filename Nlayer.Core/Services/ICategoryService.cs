using Nlayer.Core.Dtos;
using Nlayer.Core.Models;

namespace Nlayer.Core.Services
{
    public interface ICategoryService : IService<CategoryEntity>
    {

        Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int categoryid);



    }
}
