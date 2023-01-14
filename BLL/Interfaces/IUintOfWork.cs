using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUintOfWork: IDisposable
    {//segnetsher proop
        IGenericRepository<TEntity> reposatery<TEntity>() where TEntity : class;
        Task<int> complet();

    }
}
