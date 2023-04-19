﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
namespace Application.Features.Categories.Commands.DeleteProduct
{
    public class DeleteProductCommand:IRequest<bool>
    {
        public long Id { set; get; }

    }
}
