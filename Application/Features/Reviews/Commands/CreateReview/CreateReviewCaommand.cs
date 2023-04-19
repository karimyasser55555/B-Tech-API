using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelDto.CategoryDto;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Reviews.Commands.CreateProduct
{
    public class CreateReviewCaommand:IRequest<bool>
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rate { get; set; }
        public DateTime Date { get; set; }
        public int userId { get; set; }
        public long productId { get; set; }
       public CreateReviewCaommand(string comment, int  rate, DateTime Date,int userId ,long Productid)
        {
            this.Comment = comment;
            this.Rate = rate;
            this.Date = Date;
            this.productId = Productid;
            this.userId= userId;
           
        }

         public CreateReviewCaommand() { }

        
    }
}
