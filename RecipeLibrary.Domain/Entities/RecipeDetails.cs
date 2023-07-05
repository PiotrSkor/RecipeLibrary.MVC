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
        [Required(ErrorMessage ="Name should be beetwen 3 and 20 letters.")]
        [StringLength(20,MinimumLength = 2, ErrorMessage ="Name should be beetwen 3 and 20 letters.")]
        public string Name { get; set; } = default!;

        [StringLength(50, MinimumLength = 10, ErrorMessage = "Description should be beetwen 10 and 50 letters.")]
        public string? DescriptionShort { get; set; }
        public string? DescriptionLong { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string EncodedName { get; set; } = default!;

        public void EncodingName() => EncodedName = Name.ToLower().Replace(" ", "-");

    }
}
