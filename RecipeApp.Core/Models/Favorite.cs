﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeApp.Core.Models.Base;

namespace RecipeApp.Core.Models
{
    public class Favorite:BaseEntity
	{
		public string UserId { get; set; }
		public User User { get; set; }

		public int RecipeId { get; set; }
		public Recipe Recipe { get; set; }
	}
}
