using AdminDashBoard.ViewModel;
using ApiContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminDashBoard.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReviewController : Controller
    {
        private readonly DBContext dBContext;
        private readonly IWebHostEnvironment _env;
        public ReviewController(DBContext _dBContext, IWebHostEnvironment env)
        {
            dBContext = _dBContext;
            _env = env;
        }


        // GET: ReviewController
        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }

            ViewBag.product = new SelectList(dBContext.Products.Select(a => new GetAllProduct { Id = a.Id, Name = a.Name }), "Id", "Name");
            ViewBag.UserName = new SelectList(dBContext.Users.Select(a => new GetAllProduct { Id = a.Id, Name = a.UserName }), "Id", "Name");

            



            var data = dBContext.Reviews.Select(a => new GetAllReview
            {
                Id = a.Id,
                Comment = a.Comment,
                 Rate= a.Rate,
                Date = a.Date,
                Username=string.Concat( dBContext.Users.Where(b => b.Id==a.UserId).Select(b=>b.UserName)),
                Productname=string.Concat( dBContext.Products.Where(b => b.Id == a.ProductId).Select(b => b.Name)),
            });
            return View(data);

        }

        // GET: ReviewController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReviewController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReviewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
