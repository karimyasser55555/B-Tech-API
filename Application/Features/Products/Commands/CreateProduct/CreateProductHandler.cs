using Application.Contracts;
using MediatR;
using System;
using ModelDto;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDto.CategoryDto;
using Domain;


namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCaommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        public CreateProductHandler(IProductRepository productRepository,ICategoryRepository categoryRepository) {

            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        

        public async Task<bool> Handle(CreateProductCaommand request, CancellationToken cancellationToken)
        {
            
            var file = request.file;
            if (file == null || file.Length == 0)
                return false;


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
            string ImagePath = null;
            if (file != null)
                ImagePath = filePath;
            var min = new Product()
            {
                Name = request.Name,
                NameArabic = request.NameArabic,
                DiscriptionArabic=request.DescriptionArabic,
                Discription = request.Description,
                Discount= request.Discount,
               CategoryId=request.CategoryId,
               Price=request.Price,
               ImagePath=ImagePath

            };
            if (min != null)
            {
                await _productRepository.CreateAsync(min);
                return true;
            }
            else
                return false;
              
        }
    }
}
