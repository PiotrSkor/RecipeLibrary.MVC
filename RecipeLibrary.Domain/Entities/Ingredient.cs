using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeLibrary.Domain.Entities
{
    public class Ingredient
    {
        public string NameIng { get; set; }
        public decimal Value { get; set; }
        public string Type { get; set; }
    }
}
