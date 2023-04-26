using Nlayer.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core.Repositories
{
    public interface ICategoryRepository:IGenericRepository<CategoryEntity>
    {
        Task<CategoryEntity> GetSingleCategoryByIdWithProductsAsync(int categoryid);

    }
}
