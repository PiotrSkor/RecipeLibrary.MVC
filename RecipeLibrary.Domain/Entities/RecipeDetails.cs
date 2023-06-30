using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLibrary.Domain.Entities
{
    public class RecipeDetails
    {
        public string RecipeName { get; set; } = default!;
        public string? RecipeDescriptionShort { get; set; }
        public string Ingredients { get; set; } = default!;
        public string IngredientsValue { get; set; } = default!;
        public string RecipeDescriptionLong { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string EncodedName { get; set; } = default!;

        public void EncodingName() => RecipeName = RecipeName.ToLower().Replace(" ", "-");

    }
}
