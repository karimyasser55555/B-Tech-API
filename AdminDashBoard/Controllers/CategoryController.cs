using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AdminDashBoard.ViewModel;
using ApiContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Domain;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Azure.Core;
using AdminDashBoard.Models;

namespace AdminDashBoard.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly HttpClient _httpClient = new HttpClient();

        private readonly DBContext dBContext;
      
        public CategoryController(DBContext _dBContext)
        {
            dBContext = _dBContext;
             
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }

            List<GetAllCategory> getAllCategories = new List<GetAllCategory>(); ;
            
            var data = dBContext.Categories.Select(a => new GetAllCategory
            {
                Id = a.Id,
                Name = a.Name,
                NameArabic = a.NameArabic,
                ImagePath = a.ImagePath
            });
            return View(data);
        }




        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }

            return View();
        }

        // GET: Category/Create
        public async Task<ActionResult> Create()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }
            
            var viewModel = new Models.Category
            {
                category = new SelectList(dBContext.Categories.Select(a=> new GetAllCategory {Id=a.Id,Name=a.Name }), "Id", "Name")
            };
            
            if(viewModel==null)
            {
                return View();
            }
            else
            return View(viewModel);
        }

        // POST: Category/Create
        [HttpPost]
        public async Task< ActionResult> Create(Models.Category category)
        {
            
            var file = category.Images;
            if (file == null || file.Length == 0)
                return BadRequest("Please select an image");

            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string imagePath = System.IO.Path.Combine(currentDirectory, "CategoryImages");
            if (!System.IO.Directory.Exists(imagePath))
            {
                System.IO.Directory.CreateDirectory(imagePath);
            }
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(imagePath, fileName);

           

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            category.ImagePath = filePath;
             
            // var cate = dBContext.Categories.Where(e => e.Id == category).FirstOrDefault();
            var min = new Domain.Category()
            {
                Name = category.Name,
                NameArabic = category.NameArabic,
                ImagePath = category.ImagePath,
                parentId =category.ParentCategory  ,
                
            };
            await dBContext.Categories.AddAsync(min);
            await dBContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }


        // GET: Category/Edit/5
        public async Task< ActionResult> Edit(int Id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }

            var category =  dBContext.Categories.Where(a=>a.Id==Id).FirstOrDefault();
            if (category == null)
                return NotFound();
            else
            {


                Models.Category min = new Models.Category();
                min.Id = category.Id;
                min.Name = category.Name;
                min.NameArabic = category.NameArabic;
                min.ImagePath = category.ImagePath;
                min.category = new SelectList(dBContext.Categories.Select(a => new GetAllCategory { Id = a.Id, Name = a.Name }), "Id", "Name");



                return View(min);
            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Models.Category category )
        {
            var cat = await dBContext.Categories.FirstOrDefaultAsync(p => p.Id == category.Id);

            if (cat == null)
            {
                return NotFound();
            }
          //  var category = dBContext.Categories.Where(e => e.Id == product.category.Id).FirstOrDefault();

            var file = category.Images;
            if (file == null || file.Length == 0)
                return BadRequest("Please select an image");

            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string imagePath = System.IO.Path.Combine(currentDirectory, "CategoryImages");
            if (!System.IO.Directory.Exists(imagePath))
            {
                System.IO.Directory.CreateDirectory(imagePath);
            }
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(imagePath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            cat.ImagePath = filePath;
            // Update the properties of the product
            cat.Name = category.Name;
            cat.NameArabic = category.NameArabic;
            cat.ImagePath = category.ImagePath;
            cat.parentId = category.ParentCategory;
            // Save changes to the database
            dBContext.SaveChanges();

            // Redirect back to the product details page
            return RedirectToAction("Index");

        }
           
 



    // POST: Category/Delete/5
    [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var cat = dBContext.Categories.FirstOrDefault(a=>a.Id== Id);
            if (cat != null)
            { 
                dBContext.Categories.Remove(cat);
                 dBContext.SaveChanges();
                return RedirectToAction("Index","Home");

            }
            else
                return BadRequest("Error!");

        }
    }
}
