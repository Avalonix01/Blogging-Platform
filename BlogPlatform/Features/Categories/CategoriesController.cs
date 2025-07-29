using BlogPlatform.Features.Categories.Create;
using BlogPlatform.Features.Categories.Delete;
using BlogPlatform.Features.DTOs.CategoryDTOs;
using BlogPlatform.Features.Categories.Get;
using Microsoft.AspNetCore.Mvc;
using BlogPlatform.Endpoints;
using MediatR;

namespace BlogPlatform.Features.Categories;

[ApiController]
[Route("api/[controller]")]

public class CategoriesController(IMediator mediator)
    : ControllerBase
{
    [HttpGet(ApiEndpoints.V1.Categories.GetAll)]
    public async Task<ActionResult<List<CategoryDto>>> GetCategories()
    {
        var categories = await mediator.Send(new GetCategoriesQuery());
        return Ok(categories);
    }

    [HttpPost(ApiEndpoints.V1.Categories.Create)]
    public async Task<ActionResult<Guid>> CreateCategory([FromBody] CreateCategoryCommand command)
    {
        var categoryId = await mediator.Send(command);
        return Ok(categoryId);
    } 
    
    [HttpDelete(ApiEndpoints.V1.Categories.Delete)]
    public async Task<IActionResult> DeleteCategory(Guid categoryId)
    {
        var category = await mediator.Send(new DeleteCategoryCommand(categoryId));
        return category ? NoContent() : NotFound();
    }
}