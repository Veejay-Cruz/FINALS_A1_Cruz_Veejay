using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend.Data; // Assuming you have a Data namespace with RecipeDbContext  
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    // localhost:xxxx/api/Recipe  
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeDbContext dbContext;

        public RecipeController(RecipeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // https://localhost:portnumber/api/recipe  
        [HttpGet]
        public IActionResult GetAllRecipe()
        {
            var allRecipe = dbContext.Recipes.ToList(); // Corrected: Invoke ToList() method  

            return Ok(allRecipe); // Return the actual list of recipes  
        }
    }
}
