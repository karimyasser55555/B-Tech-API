using ApiContext;
using Application.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class RviewRepository : Repository<Review, int>, IReviewRepository
    {

        public RviewRepository(DBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Review>> FilterAsync()
        {
            return await _context.Reviews.ToListAsync();
        }
    }
}
