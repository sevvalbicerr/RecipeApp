using RecipeApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Core.ViewModels.AddViewModel
{
    public class IngredientAddViewModel
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        // miktarın birimi kg,lt vs
        public string Unit { get; set; }
    }
}
