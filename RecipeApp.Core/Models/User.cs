using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Core.Models
{
    public class User:IdentityUser
    {

        public int Id { get; set; }
        public string FullName { get; set; }

        public ICollection<Recipe> Recipes { get; set; }=new List<Recipe>();
        public ICollection<Favorite> Favorites { get; set; }= new List<Favorite>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
