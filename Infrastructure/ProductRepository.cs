using ApiContext;
using Application.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ProductRepository : Repository<Product, long>, IProductRepository
    {

        public ProductRepository(DBContext dBContext) : base(dBContext)
        {


        }
        public async Task<Product> GetByIdAsyc(long Id)
        {
            return await _context.Products.Include(e => e.category)
                .Where(e => e.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> FilterAsync(int? CategoryId,string? Name,string? ArabicName
            ,int? Discount,float? Morethan,float? Lessthan)
        {
            #region
            //var query = await _context.Products.Include(e=>e.category).ToListAsync();
            //if (CategoryId != null)
            //    query = query.Where(e => e.category.Id==CategoryId).ToList();
            //if (Discount != null)
            //    query = query.Where(e => e.Discount>0).ToList();
            //if (Morethan != null)
            //    query = query.Where(e => e.Price < Morethan).ToList();

            //if (Lessthan != null)
            //    query = query.Where(e => e.Price > Lessthan).ToList();
            //if (Discount != null)
            //    query = query.Where(e => e.Discount > 0).ToList();
            //if (Name != null)
            //    query =query.Where(e =>e.Name.ToLower().Contains(Name.ToLower())).ToList();
            //if (ArabicName != null)
            //    query = query.Where(e => e.NameArabic.ToLower().Contains(ArabicName.ToLower())).ToList();
            #endregion
            
              var query = await _context.Products.Include(e => e.category)
            .Where(d => CategoryId == null || d.category.Id == CategoryId)
            .Where(d => ArabicName == null || d.NameArabic.ToLower().Contains( ArabicName))
            .Where(d => Name == null || d.Name.ToLower().Contains(Name))
            .Where(d => Discount == null || d.Discount == Discount)
            .Where(d => Morethan == null || d.Price > Morethan)
            .Where(d => Lessthan == null || d.Price < Lessthan).ToListAsync();

                return  query;
            
              
          
        }



    }
}


 
