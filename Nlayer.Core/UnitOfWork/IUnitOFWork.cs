namespace Nlayer.Core.IUnitOfWork
{
    public interface IUnitOFWork
    {
        Task CommitAsync();
        void Commit();
    }
}
