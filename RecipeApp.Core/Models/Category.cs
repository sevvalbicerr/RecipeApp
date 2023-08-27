using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeApp.Core.Models.Base;

namespace RecipeApp.Core.Models
{
    public class Category:BaseEntity
	{
        public string Name { get; set; }


        public ICollection<Recipe> Recipes { get; set; }
    }
}
