using Microsoft.AspNetCore.Mvc;
using ApiContext;
using Application.Contracts;
using ModelDto;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly DBContext _Context;
        private readonly IWishListRepository _wishList;

        public WishListController(DBContext context,IWishListRepository wishList)
        {
            _Context = context;
            _wishList = wishList;

        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WishList wishList)
        {
            var wish=await _Context.WishList.Where(e=>e.UserID==wishList.UserID).FirstOrDefaultAsync();

            if(wish!=null)
                return NotFound("This account has wishList");
            wishList.DataAdded = DateTime.Now;
            bool b = await _wishList.CreateAsync(wishList);
           
            if (b)
                return Ok();
            return NotFound("Some Error Occure");

        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Remove(int Id)
        {
            var wish = _Context.WishList.Where(e => e.Id==Id).FirstOrDefault();

            if (wish == null)
                return NotFound("No Wish list with this id");

            await _wishList.DeleteAsync(Id);
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetWishList(int Id)
        {
            
          var wishlist= await _wishList.GetByIdAsyc(Id);

            if (wishlist != null)
                return Ok(wishlist);
            return NotFound("WishList Not Found");
            
        }
        [HttpPost]
        public   async Task<IActionResult> AddProduct([FromBody]WishListDTO wishList)
        {
         
            bool b=await _wishList.AddProduct(wishList.UserID, wishList.productId);
            if (b==true)
                return Ok();
            return NotFound("Some Error Occure");

        }

        [HttpDelete]
        public async Task<IActionResult> RemoveProduct([FromBody]WishListRemoveDto removeDto)
        {
            bool b =await _wishList.RemoveProduct(removeDto.wishListId,removeDto.productId);

            if (b == false)
                return NotFound("No product found");

            
            return Ok("Product is deleted");
        }
    }
}
