using AutoMapper;
using Nlayer.Core.Dtos;
using Nlayer.Core.IUnitOfWork;
using Nlayer.Core.Models;
using Nlayer.Core.Repositories;
using Nlayer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Service.Services
{
    public class CategoryService : Service<CategoryEntity>, ICategoryService
    {
        private readonly ICategoryRepository _categoryrepository;
        private readonly IMapper _mapper;


        public CategoryService(IGenericRepository<CategoryEntity> repository, IUnitOFWork unitOfWork, ICategoryRepository categoryrepository,IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryrepository = categoryrepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithProductsDto>> GetSingleCategoryByIdWithProductsAsync(int categoryid)
        {
            var category = await _categoryrepository.GetSingleCategoryByIdWithProductsAsync(categoryid);
            var categoryDto=_mapper.Map<CategoryWithProductsDto>(category);
            return CustomResponseDto<CategoryWithProductsDto>.Succes(200, categoryDto);

        }
    }
}
