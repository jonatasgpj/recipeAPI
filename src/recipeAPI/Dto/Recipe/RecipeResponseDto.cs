namespace recipeAPI.Dto.Recipe
{
    public class RecipeResponseDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Instructions { get; set; }
        public required List<RecipeIngredientDto> Ingredients { get; set; }
    }

    public class RecipeIngredientDto
    {
        public int IngredientId { get; set; }
        public required string IngredientName { get; set; }
        public required string Unit { get; set; }
        public double Quantity { get; set; }
    }
}
