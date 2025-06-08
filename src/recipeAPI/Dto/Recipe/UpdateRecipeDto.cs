namespace recipeAPI.Dto.Recipe
{
    public class UpdateRecipeDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Instructions { get; set; }

        public required List<CreateRecipeItemDto> Ingredients { get; set; }
    }
}
