using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nlayer.Core.IUnitOfWork
{
    public interface IUnitOFWork
    {
        Task CommitAsync();
        void Commit();
    }
}
