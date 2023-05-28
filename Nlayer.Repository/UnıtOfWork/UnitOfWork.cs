using Nlayer.Core.IUnitOfWork;

namespace Nlayer.Repository.UnıtOfWork
{
    public class UnitOfWork : IUnitOFWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;

        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();

        }
    }
}
