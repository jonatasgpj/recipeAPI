using recipeAPI.Models;

namespace recipeAPI.Services.Recipe
{
    public interface IRecipeInterface
    {
        Task<ResponseModel<List<RecipeModel>>> GetRecipes();
        Task<ResponseModel<RecipeModel>> GetRecipeById(int idRecipe);
        Task<ResponseModel<RecipeModel>> GetRecipeByIngredient(int idIngredient);

    }
}
