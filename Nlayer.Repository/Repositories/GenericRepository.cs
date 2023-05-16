using Microsoft.EntityFrameworkCore;
using Nlayer.Core.Repositories;
using System.Linq.Expressions;

namespace Nlayer.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        //sadece miras alınan sınıflardan erişilsin
        private readonly DbSet<T> _dbSet;
        //farklı contextler set edilmesin 
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);

        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
            //datayı aldıktan sonra hemen veritabanıına yansımasın tolist diiynce dbye yansısın
            //anında cekmş oldugu dataları hemen memorye alıp durumu anlık izleme 
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);

        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
            //sadece durumunu değiştiridği için herhangi bir silme işlemi almadığı için asenkron metodu yok repoda (propertysını set ediyor yuklu iş değil)
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);

        }



        //Task<T> IGenericRepository<T>.AddRangeAsync(IEnumerable<T> entities)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
