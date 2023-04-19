using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Core.Models
{
	public class Comment:BaseEntity
	{
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
