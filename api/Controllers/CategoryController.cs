using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiContext;
using MediatR;
using Application.Features.Categories.Queries.GetAllCategories;
using Domain;
using Application.Features.Categories.Queries.GetCategoryById;
using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using ModelDto;
using ModelDto.CategoryDto;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> GetAllCategory([FromQuery] GetAllCategoriesQuery query)
        {
            try
            {
              
                  return Ok(await _mediator.Send(query));

            }
            catch (Exception e)
            {
                return NotFound("Error 404!");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {

              return Ok(await _mediator.Send(new GetCategoryByIdQuery() {Id=id }));

               
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromForm] CreateCategoryCaommand categor
          )
        {
            try
            {
                

                return Ok(await _mediator.Send(new CreateCategoryCaommand
               (categor.Name,
               categor.NameArabic,
                 
               categor.file,
               categor.ParentCategory
               )));


            }
            catch (Exception e) 
            {
                return NotFound(e.Message);
            }
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryCommand category)
        {
            try
            {

                return Ok(await _mediator.Send(new UpdateCategoryCommand
               (category.Id,
               category.NameArabic,
                    category.Name,
               category.file,
               category.ParentCategory
                ))) ;
 

            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }


        [HttpDelete("{id}") ]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            
             return Ok(await _mediator.Send(new DeleteCategoryCommand() { Id = id }));
             
        }
    }
}
