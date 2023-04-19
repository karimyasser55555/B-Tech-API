using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface ICategoryRepository : IRepository<Category,int>
    {

        Task<IEnumerable<Category>> FilterAsync(string? Name,string?NameArabic);

    }
}
