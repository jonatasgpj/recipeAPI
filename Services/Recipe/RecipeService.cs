using Microsoft.EntityFrameworkCore;
using recipeAPI.Data;
using recipeAPI.Models;

namespace recipeAPI.Services.Recipe
{
    public class RecipeService : IRecipeInterface
    {
        private readonly AppDbContext _context;
        public RecipeService(AppDbContext context) 
        {
            _context = context;
        }



        public async Task<ResponseModel<RecipeModel>> GetRecipeById(int idRecipe)
        {
            ResponseModel<RecipeModel> response = new ResponseModel<RecipeModel>();
            try
            {
                var recipe = await _context.Recipes.FirstOrDefaultAsync(recipeDb => recipeDb.Id == idRecipe);
                if (recipe == null) 
                {
                    response.Message = "no recipe found";
                    return response; 
                }
                response.Data = recipe;
                response.Message = "recipe found";
                return response;



            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
            
        }

        public async Task<ResponseModel<RecipeModel>> GetRecipeByIngredient(int idIngredient)
        {
            ResponseModel<RecipeModel> response = new ResponseModel<RecipeModel>();
            try
            {
                var recipeItem = await _context.RecipeItems
                    .Include(i => i.Recipe)
                    .FirstOrDefaultAsync(ingredientDb => ingredientDb.IngredientId == idIngredient);

                if (recipeItem == null)
                {
                    response.Message = "404";
                    return response;
                }
                response.Data = recipeItem.Recipe;
                response.Message = "200";
                return response;


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<RecipeModel>>> GetRecipes()
        {
            ResponseModel<List<RecipeModel>> response = new ResponseModel<List<RecipeModel>>();
            try
            {
                var recipes = await _context.Recipes.ToListAsync();

                response.Data = recipes;

                return response;
                response.Message = "all recipes have been listed";


            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
