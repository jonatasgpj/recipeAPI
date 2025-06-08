namespace recipeAPI.Dto.Recipe
{
    public class CreateRecipeItemDto
    {
        public int IngredientId { get; set; }
        public required double Quantity { get; set; }
    }
}
