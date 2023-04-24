using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Dal.Seeds
{
    public class IngredientSeed : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasData(new Ingredient()
            {
                Id = 1,
                Name = "Domates",
                Amount = 1,
                Unit = "adet",
                RecipeId = 1,

            },
            new Ingredient()
            {
                Id = 2,
                RecipeId = 1,
                Amount = 1,
                Unit = "kaşık",
                Name = "Tuz"
            },
            new Ingredient()
            {
                Id = 3,
                RecipeId = 2,
                Amount = 200,
                Name = "Et",
                Unit = "gram"

            }
            );
        }
    }
}
