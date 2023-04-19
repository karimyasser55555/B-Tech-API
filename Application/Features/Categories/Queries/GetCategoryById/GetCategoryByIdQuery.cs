using MediatR;
using ModelDto.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDto;
namespace Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<MinimalCategoryDetails>
    {
        public int Id { set; get; }
    }
}
