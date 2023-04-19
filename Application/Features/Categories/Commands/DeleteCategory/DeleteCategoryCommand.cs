using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand:IRequest<bool>
    {
        public int Id { set; get; }

    }
}
