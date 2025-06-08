using System.Text.Json.Serialization;

namespace recipeAPI.Models
{
    public class RecipeModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        [JsonIgnore]
        public required string Instructions { get; set; }
        [JsonIgnore]
        public ICollection<RecipeItemModel> Ingredients { get; set; } = new List<RecipeItemModel>();


    }
}
