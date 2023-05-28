using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Nlayer.Core.Dtos;
using Nlayer.Core.IUnitOfWork;
using Nlayer.Core.Models;
using Nlayer.Core.Repositories;
using Nlayer.Core.Services;
using Nlayer.Service.Exceptions;
using System.Linq.Expressions;

namespace Nlayer.Caching
{
    public class ProductServiceWithCaching : IProductService
    {
        private const string CacheProductKey = "productsCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IProductRepository _repository;
        private readonly IUnitOFWork _unitofWork;

        public ProductServiceWithCaching(IUnitOFWork unitofWork, IProductRepository repository, IMemoryCache memoryCache, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _repository = repository;
            _memoryCache = memoryCache;
            _mapper = mapper;

            //decorater desıng pattern
            if (!_memoryCache.TryGetValue(CacheProductKey, out _))//cache de deger yoksa repositoryden al kaydet
            {
                _memoryCache.Set(CacheProductKey, _repository.GetProductWithCategory().Result);
            }



        }
        public async Task<ProductEntity> AddAsync(ProductEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitofWork.CommitAsync();
            await CacheAllProductsAsync();
            return entity;

        }

        public async Task<IEnumerable<ProductEntity>> AddRangeAsync(IEnumerable<ProductEntity> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitofWork.CommitAsync();
            await CacheAllProductsAsync();
            return entities;
        }

        public Task<bool> AnyAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<ProductEntity>>(CacheProductKey));
        }

        public Task<ProductEntity> GetByIdAsync(int id)
        {
            var product = _memoryCache.Get<List<ProductEntity>>(CacheProductKey).FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                throw new NotFoundException($" (id) not found!");
            }
            else
                return Task.FromResult(product);
        }

        public Task<List<ProductWithCategory>> GetProductWithCategory()
        {
            var product = _memoryCache.Get<IEnumerable<ProductEntity>>(CacheProductKey);
            var productsWithCategoryDto = _mapper.Map<List<ProductWithCategory>>(product);
            return Task.FromResult(productsWithCategoryDto);
        }

        public async Task RemoveAsync(ProductEntity entity)
        {
            _repository.Remove(entity);
            await _unitofWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task RemoveRange(IEnumerable<ProductEntity> entities)
        {
            _repository.RemoveRange(entities);
            await _unitofWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public async Task UpdateAsync(ProductEntity entity)
        {
            _repository.Update(entity);
            await _unitofWork.CommitAsync();
            await CacheAllProductsAsync();
        }

        public IQueryable<ProductEntity> Where(Expression<Func<ProductEntity, bool>> expression)
        {
            return _memoryCache.Get<List<ProductEntity>>(CacheProductKey).Where(expression.Compile()).AsQueryable();
        }
        public async Task CacheAllProductsAsync()
        {
            _memoryCache.Set(CacheProductKey, await _repository.GetAll().ToListAsync());

        }


    }
}
