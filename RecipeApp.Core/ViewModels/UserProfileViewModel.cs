﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Core.ViewModels
{
	public class UserProfileViewModel
	{
        public string Id { get; set; }
        public string FullName { get; set; }
		public string UserName { get; set; }
        public string Phone { get; set; }
		public string Email { get; set; }
    }
}
