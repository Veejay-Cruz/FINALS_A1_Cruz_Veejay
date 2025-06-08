using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using backend.Data; // Assuming you have a Data namespace with RecipeDbContext  
using Microsoft.EntityFrameworkCore;
using backend.Models;

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


        //retrieve all recipes
        // https://localhost:portnumber/api/recipe  
        [HttpGet]
        public IActionResult GetAllRecipe()
        {
            var allRecipe = dbContext.Recipes.ToList(); // Corrected: Invoke ToList() method  

            return Ok(allRecipe); // Return the actual list of recipes  
        }



        //get specific recipe
        [HttpGet]
        [Route("{id:int}")] // Route to get a recipe by its ID
        public IActionResult GetRecipeById(int id)
        {
            var recipe = dbContext.Recipes.Find(id); // Corrected: Use Find method to retrieve the recipe by ID

            if (recipe is null)
            {
                return NotFound(); // Return 404 if the recipe is not found
            }

            return Ok(recipe); // Return the found recipe

        }



        //create recipe
        [HttpPost]
        public IActionResult AddRecipe(AddRecipeDto addRecipeDto)
        {
            var recipeEntity = new Recipe() // Corrected: Use the Recipe constructor to create a new instance
            {
                Name = addRecipeDto.Name,
                ImageUrl = addRecipeDto.ImageUrl,
                Ingredients = addRecipeDto.Ingredients, 
                Instructions = addRecipeDto.Instructions
            };

            dbContext.Recipes.Add(recipeEntity);
            dbContext.SaveChanges();
            return Ok(recipeEntity); // Return the created recipe entity

        }


        //update recipe
        [HttpPut]
        [Route("{id:int}")] // Route to update a recipe by its ID
        public IActionResult UpdateRecipe(int id, UpdateRecipeDto updateRecipeDto)
        {
            var recipe = dbContext.Recipes.Find(id); // Corrected: Use Find method to retrieve the recipe by ID
            if (recipe is null)
            {
                return NotFound(); // Return 404 if the recipe is not found
            }
            // Update the recipe properties
            recipe.Name = updateRecipeDto.Name;
            recipe.ImageUrl = updateRecipeDto.ImageUrl;
            recipe.Ingredients = updateRecipeDto.Ingredients;
            recipe.Instructions = updateRecipeDto.Instructions;
            dbContext.SaveChanges(); // Save changes to the database
            return Ok(recipe); // Return the updated recipe
        }


        //delete recipe
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteRecipe(int id)
        {
            var recipe = dbContext.Recipes.Find(id);

            if(recipe is null)
            {
                return NotFound();
            }

            dbContext.Recipes.Remove(recipe);
            dbContext.SaveChanges();

            return Ok("Recipe Deleted");


        }




        ////create recipe
        //[HttpPost]
        //public IActionResult CreateRecipe([FromBody] Recipe recipe)
        //{
        //    if (recipe == null)
        //    {
        //        return BadRequest("Recipe cannot be null");
        //    }
        //    dbContext.Recipes.Add(recipe);
        //    dbContext.SaveChanges();
        //    return CreatedAtAction(nameof(GetAllRecipe), new { id = recipe.Id }, recipe);
        //}




    }
}
