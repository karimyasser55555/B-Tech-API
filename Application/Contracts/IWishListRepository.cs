using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
namespace Application.Contracts
{
    public interface IWishListRepository:IRepository<WishList,int>
        
    {
        Task<IEnumerable<WishList>> GetAll();
        public Task<bool> AddProduct(int UserID, long productId);
        public Task<bool> RemoveProduct(int wishListId, long productId);
    }
}
