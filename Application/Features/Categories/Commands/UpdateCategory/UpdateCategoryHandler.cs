using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {


        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categ=await _categoryRepository.GetByIdAsyc(request.Id);

            var file = request.file;
            if (file == null || file.Length == 0)
                return false;

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
            string ImagePath = null;
            if (file != null)
                ImagePath = filePath;
            if (categ!=null)
            {
               
                categ.Name = request.Name;
                categ.NameArabic = request.NameArabic;
                categ.ImagePath=ImagePath;
                if(request.ParentCategory != null) 
                categ.parentId = request.ParentCategory;
                await _categoryRepository.UpdateAsync(categ);
                return true;
                
               
            }
            return false;

        }
    }
}
