using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Core.Models
{
	public class Ingredient:BaseEntity
	{
        public string Name { get; set; }

        //TODO: tipi ne olmalı? int olmayabilir
        public decimal Amount { get; set; }
        // miktarın birimi kg,lt vs
		public string Unit { get; set; }

		public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

    }
}
