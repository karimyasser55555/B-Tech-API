using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDto
{
    public class WishListRemoveDto
    {
        public long productId { set; get; }

        public int wishListId { set; get; }
    }
}
