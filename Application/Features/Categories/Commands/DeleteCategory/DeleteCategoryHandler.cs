using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IProductRepository _categoryRepository;
        public DeleteCategoryHandler(IProductRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

       

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var IsExist =await _categoryRepository.GetByIdAsyc(request.Id);
            if(IsExist!=null)
            {
                await _categoryRepository.DeleteAsync(request.Id);

                return true;
            }
            return false;
        }
    }
}
