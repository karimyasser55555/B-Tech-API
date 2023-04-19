using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface  IRepository<TEntity,TId>where TEntity:class
    {
      Task< TEntity>?  GetByIdAsyc(TId? id);

        
        Task< bool> CreateAsync(TEntity Entity);
        Task<bool> UpdateAsync(TEntity Entity);
      Task< bool>  DeleteAsync(TId? id);

        Task Save();

    }
}
