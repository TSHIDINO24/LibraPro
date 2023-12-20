using LibraProFinalAPI.dto;
using LibraProFinalAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraProFinalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly LibraProFinalDataContext _Context;

        public CategoryController(LibraProFinalDataContext context)
        {
            _Context = context;
        }

        //Adding a Category
        [HttpPost]
        [Route("addcategory")]
        public async Task<IActionResult> Addcategory([FromBody] AddCategorydto category)
        {
            try
            {
                if (category == null)
                {
                    return BadRequest("Please enter your category");
                }
                var categ = _Context.Categories.Where(u => u.CategoryName == category.CategoryName).FirstOrDefault();
                if (categ != null)
                {
                    return BadRequest("Category does exist");
                }
                else
                {
                    categ = new Category();

                    categ.CategoryName = category.CategoryName;

                    _Context.Categories.Add(categ);
                    await _Context.SaveChangesAsync();

                    return Ok(new { message = "Category added successfully" });
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Get all registered categories
        [HttpGet]
        [Route("getallcategories")]
        public async Task<IActionResult> Getallcategories()
        {
            try
            {
                List<Category> cat = _Context.Categories.ToList();
                if (cat != null)
                {
                    return Ok(cat);
                }
                return BadRequest("No categories registered");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
