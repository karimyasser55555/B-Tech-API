using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IReviewRepository: IRepository<Review,int>
    {
        Task<IEnumerable<Review>> FilterAsync();
    }
}
