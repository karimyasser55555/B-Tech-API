using ApiContext;
using Application.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class WishListRepository:Repository<WishList, int>, IWishListRepository
    {
        public WishListRepository(DBContext context) : base(context)
        {
        }

        public async Task<bool> CreateAsync(WishList wishList)
        {

            try
            {
                await _context.WishList.AddAsync(wishList);
               await Save();
                return true;
            }catch(Exception ex)
            {
                return false;
            }

            
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            try
            {
                var wish = _context.WishList.Where(e => e.Id == Id).FirstOrDefault();
              
              
                if (wish != null)
                {
                    _context.WishList.Remove(wish);
                   await Save();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> AddProduct(int UserID,long productId)
        {

           
            var wishList=await _context.WishList.Where(e=>e.UserID==UserID).FirstOrDefaultAsync();
            
            var product = await _context.Products.FindAsync(productId);
            if (wishList!=null&&product!=null)
            {
                wishList.AddProduct(product);
                await Save();
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveProduct(int wishListId, long productId)
        {
            var wishList = await _context.WishList.FindAsync(wishListId);

            var product = await _context.Products.FindAsync(productId);
            if (wishList != null && product != null)
            {
                wishList.RemoveProduct(product);
               await Save();
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<WishList>> GetAll()
        {
            return await _context.WishList.Include(prod=>prod.products).ToListAsync();
        }

        public async Task<WishList>? GetByIdAsyc(int Id)
        {
            return await _context.WishList.Include(p=>p.products).Where(e=>e.Id==Id).FirstOrDefaultAsync();

        }

        private async Task Save()
        {
           await _context.SaveChangesAsync();
        }

        public Task<bool> UpdateAsync(WishList Entity)
        {
            throw new NotImplementedException();
        }
    }
}
