using Microsoft.AspNetCore.Mvc;
using MyFirstProject.Models;
using MyFirstProject.Repositoriesl;

namespace MyFirstProject.Controllers;

[ApiController]
[Route("category")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryRepository _repository;

    public CategoryController(ILogger<CategoryController> logger, ICategoryRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Category>>> getCategory()
    {
        var result = await _repository.GetCategoryList();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Category>> CreateCategory([FromBody] Category item)
    {
        var result = await _repository.Create(item);
        return result;
    }

[HttpGet("{id}")]
public async Task<ActionResult<Category>> getCategoryById([FromRoute]long id){
  var result = await _repository.GetCategoryById(id);
  if(result == null){
      return NotFound("There is no Category With given ID");
  }
  return Ok(result);
}
[HttpPut("{id}")]
 public async Task<ActionResult<Category>> UpdateCategory(long id, [FromBody] Category item)
    {
        await _repository.Update(id,item);
        return NoContent();
    }

}