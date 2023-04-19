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
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(DBContext dBContext) : base(dBContext)
        {


        }
        public async Task<IEnumerable<Category>> FilterAsync(string? Name, string? NameArabic)
        {

            var query =await _context.Categories.ToListAsync();
            if (Name != null)
                query = query.Where(e => e.Name == Name).ToList();
            else if(NameArabic!=null)
                query = query.Where(e => e.NameArabic == NameArabic).ToList();

            return query;
        }
 
    }
}
