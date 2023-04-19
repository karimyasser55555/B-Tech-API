using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IProductRepository:IRepository<Product,long>
    {

        Task<IEnumerable<Product>> FilterAsync(int? categoryId,string? Name, string? ArabicName
            , int? Discount, float? Morethan, float? Lessthan);
    }
}