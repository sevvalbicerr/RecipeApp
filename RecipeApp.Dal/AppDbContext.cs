using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Dal
{
    public class AppDbContext:IdentityDbContext<User,UserRole,string>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

		public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Comment>()
	.HasOne(c => c.Recipe)
	.WithMany(r => r.Comments)
	.HasForeignKey(c => c.RecipeId)
	.OnDelete(DeleteBehavior.NoAction);

			builder.Entity<Favorite>()
	.HasOne(c => c.Recipe)
	.WithMany(r => r.Favorites)
	.HasForeignKey(c => c.RecipeId)
	.OnDelete(DeleteBehavior.NoAction);

			base.OnModelCreating(builder);
		}
	}
}
