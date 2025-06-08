namespace recipeAPI.Models
{
    public class IngredientModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Unit { get; set; }
    }
}
