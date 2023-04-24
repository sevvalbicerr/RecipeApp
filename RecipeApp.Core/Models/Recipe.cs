using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Core.Models
{
	public class Recipe:BaseEntity
	{
        public string Name { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public DateTime CreatedDate { get; set; }
        public int Score { get; set; }


        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Favorite> Favorites { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }


        


    }
}
