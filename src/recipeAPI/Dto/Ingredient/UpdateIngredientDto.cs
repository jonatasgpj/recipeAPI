﻿using recipeAPI.Dto.Recipe;

namespace recipeAPI.Dto.Ingredient
{
    public class UpdateIngredientDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Unit { get; set; }

    }
}
