using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLibrary.Domain.Entities
{
    public class RecipeDetails
    {
        [Required(ErrorMessage ="Name should be 2-20 letters")]
        [StringLength(20,MinimumLength =2)]
        public string RecipeName { get; set; } = default!;

        [StringLength(50,MinimumLength =10)]
        public string? RecipeDescriptionShort { get; set; }
        public string Ingredients { get; set; } = default!;
        public string IngredientsValue { get; set; } = default!;
        public string RecipeDescriptionLong { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string EncodedName { get; set; } = default!;

        public void EncodingName() => EncodedName = RecipeName.ToLower().Replace(" ", "-");

    }
}
