using Microsoft.AspNetCore.Mvc;
using AdminDashBoard.Models;
using Newtonsoft.Json;
using System.Text;
using AdminDashBoard.ViewModel;
using Microsoft.AspNetCore.Http;
using ApiContext;
using Domain;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace AdminDashBoard.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly DBContext dBContext;
        
        public ProductController(DBContext _dBContext)
        {
            dBContext = _dBContext;
            
        }
        private readonly HttpClient _httpClient = new HttpClient();


        [HttpGet]
        public async Task<IActionResult> Index()//string Lang, int? CategoryId, string? Name, string? ArabicName
        //    , int? Discount, float? Morethan, float? Lessthan
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }

            var data = dBContext.Products.Select(a => new GetAllProduct
            {
                Id = a.Id,
                Name = a.Name,
                NameArabic = a.NameArabic,
                ImagePath = a.ImagePath,
                Price=a.Price,
                DiscArabic=a.DiscriptionArabic,
                Discription=a.Discription,
                Discount=a.Discount
            });
            return View(data);

        }
        [HttpGet]
        public async Task<IActionResult> Details(long Id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }
            //var apiUrl = $"http://localhost:5000/api/Product/GetProductyById/{Id}";

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"http://localhost:5000/api/Product/GetProductyById/{Id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var product = JsonConvert.DeserializeObject<ProductDetails>(apiResponse);
                    return View(product);
                }

            }

        }


        public IActionResult Create()
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }

            var viewModel = new Models.Product
            {
                category = new SelectList(dBContext.Categories.Select(a=> new GetAllCategory { Id=a.Id ,Name=a.Name}), "Id", "Name")
            };

            return View(viewModel);

        }
        [HttpPost]
        public async Task<IActionResult> Create(Models.Product product)
        {

            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }

            var file = product.Images;
            if (file == null || file.Length == 0)
                return BadRequest("Please select an image");

            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string imagePath = System.IO.Path.Combine(currentDirectory, "wwwroot/ProductImages");
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

            product.ImagePath = "ProductImages/" + fileName;
            //product.ImagePath = filePath;

            //  var category = dBContext.Categories.Where(e => e.Id == product.CategoryId).FirstOrDefault();

            var min = new Domain.Product()
            {
                Name = product.Name,
                NameArabic = product.NameArabic,
                DiscriptionArabic = product.DescriptionArabic,
                Discription = product.Description,
                Discount = product.Discount,
                CategoryId = product.CategoryId,
                Price = product.Price,
                ImagePath = product.ImagePath

            };
            await dBContext.Products.AddAsync(min);
            await dBContext.SaveChangesAsync();
            return RedirectToAction("Index");
            #region
            //using (var client = new HttpClient())
            // {
            //    //var file = product.Images;
            //    //if (file == null || file.Length == 0)
            //    //    return BadRequest("Please select an image");
            //    // var imagesDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            //    // if (!Directory.Exists(imagesDirectoryPath))
            //    //    Directory.CreateDirectory(imagesDirectoryPath);

            //    //var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            //    //var filePath = Path.Combine(imagesDirectoryPath, fileName);

            //    //using (var stream = new FileStream(filePath, FileMode.Create))
            //    //{
            //    //    await file.CopyToAsync(stream);
            //    //}
            //    //product.ImagePath = filePath;
            //    //var prod = new
            //    //{
            //    //   Name= product.Name,
            //    //    NameArabic=   product.NameArabic,
            //    //    DescriptionArabic=    product.DescriptionArabic,
            //    //    Discount=   product.Discount,
            //    //    Description=   product.Description,
            //    //    CategoryId=  product.CategoryId,
            //    //    ImagePath= product.ImagePath,
            //    //    AvailUnit = product.AvailUnit,
            //    //    Price= product.Price
            //    //};

            //client.BaseAddress = new Uri("http://localhost:5000/api/Product/CreateProduct");
            //var json = JsonConvert.SerializeObject(product);
            //var content = new StringContent(json, Encoding.UTF8, "multipart/form-data");

            //content.Headers.Remove("Content-Type");
            //content.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; charset=ISO-8859-4");

            //var response = await client.PostAsync("http://localhost:5000/api/Product/CreateProduct", content);
            ////var stringContent = new MultipartContent(json, "multipart/form-data");

            ////var response = await client.PostAsync("", stringContent);
            //if (!response.IsSuccessStatusCode)
            //{
            //    throw new Exception("uiu");
            //    return View(product);
            //}
            //return RedirectToAction("Index");

        
        #endregion

    }


        public async Task<IActionResult> Delete(long id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }

            string apiUrl = $"http://localhost:5000/api/Product/DeleteProduct/{id}";

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.DeleteAsync(apiUrl);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");
            else

                return BadRequest("Error!");
        }


        public async Task<IActionResult> Update(long Id)
        {
            if (User.Identity.IsAuthenticated == true)
            {
                ViewBag.name = User.Identity.Name;
            }
            var product = await dBContext.Products.FindAsync(Id);
            if (product == null)
                return NotFound();
            else
            {


                Models.Product min = new Models.Product();
                min.Id = product.Id;
                min.Name = product.Name;
                min.NameArabic = product.NameArabic;
                min.DescriptionArabic = product.DiscriptionArabic;
                min.Description = product.Discription;
                min.Discount = product.Discount;
                min.Price = product.Price;
                min.category = new SelectList(dBContext.Categories.Select(a=> new GetAllCategory {Id=a.Id,Name=a.Name }), "Id", "Name");
                // min.ImagePath = product.ImagePath;


                return View(min);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Update(Models.Product updatedProduct)
        {

            var product = dBContext.Products.FirstOrDefault(p => p.Id == updatedProduct.Id);

            if (product == null)
            {
                return NotFound();
            }
            //var category = dBContext.Categories.Where(e => e.Id == product.category.Id).FirstOrDefault();

            var file = updatedProduct.Images;
            if (file == null || file.Length == 0)
                return BadRequest("Please select an image");
            string currentDirectory = System.IO.Directory.GetCurrentDirectory();
            string imagePath = System.IO.Path.Combine(currentDirectory, "ProductImages");
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
            updatedProduct.ImagePath = filePath;
            // Update the properties of the product
            product.Name = updatedProduct.Name;
            product.NameArabic = updatedProduct.NameArabic;
            product.Discription = updatedProduct.Description;
            product.DiscriptionArabic = updatedProduct.DescriptionArabic;
            product.Price = updatedProduct.Price;
            product.Discount = updatedProduct.Discount;
            product.AvailUnit = updatedProduct.AvailUnit;
            product.ImagePath = updatedProduct.ImagePath;
            product.CategoryId =updatedProduct.CategoryId ;
            // Save changes to the database
            dBContext.SaveChanges();

            // Redirect back to the product details page
            return RedirectToAction("Index");

        }
    }
}