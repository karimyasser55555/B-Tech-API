using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

       

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var IsExist =await _productRepository.GetByIdAsyc(request.Id);
            if(IsExist!=null)
            {
                await _productRepository.DeleteAsync(request.Id);

                return true;
            }
            return false;
        }
    }
}
