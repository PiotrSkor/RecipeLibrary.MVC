using RecipeLibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLibrary.Application.Mappings
{
    public class RecipeDetailsDto
    {
        public string Name { get; set; } = default!;
        public string? DescriptionShort { get; set; }
        public string? DescriptionLong { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string EncodedName { get; set; } = default!;

        public void EncodingName() => EncodedName = Name.ToLower().Replace(" ", "-");

    }
}
