using Application.Features.Categories.Queries.GetAllCategories;
using Application.Features.Categories.Queries.GetCategoryById;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Queries.GetAllQuery;
using Application.Features.Reviews.Commands.CreateProduct;
using Application.Features.Reviews.Commands.DeleteReview;
using Application.Features.Reviews.Commands.UpdateProduct;
using Application.Features.Reviews.Queries.GetAllQuery;
using Application.Features.Reviews.Queries.GetReviewById;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
   

    public class ReviewController : Controller
    {
        private readonly IMediator _mediator;
        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: ReviewController
        public async Task<IActionResult> GetAllReview([FromQuery] GetAllViewsQuery query)
        {
            try
            {
                var reviews = await _mediator.Send(query);

                // filter the reviews by product ID
                if (query.productId != null)
                {
                    reviews = reviews.Where(r => r.productId == query.productId);
                }

                return Ok(reviews);
            }
            catch (Exception e)
            {
                return NotFound("Error 404!");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            try
            {

                return Ok(await _mediator.Send(new GetReviewByIdQuery() { Id = id }));


            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        // GET: ReviewController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReviewController/Create
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewCaommand review)
        {
            try
            {

                return Ok(await _mediator.Send(new CreateReviewCaommand
               (

                 review.Comment,
                 review.Rate,
                 review.Date,
                 review.userId,
                 review.productId 
                ))); 


            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        // GET: ReviewController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ReviewController/Edit/5
        [HttpPatch]
        public async Task<IActionResult> UpdateReview([FromForm] UpdateReviewCommand review)
        {
            try
            {

                return Ok(await _mediator.Send(new UpdateReviewCommand
                (
                 review.Comment, review.Rate, review.Date, review.userId, review.productId 
                )));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }


        // GET: ReviewController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ReviewController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {

            return Ok(await _mediator.Send(new DeleteReviewCommand() { Id = id }));

        }
    }
}
