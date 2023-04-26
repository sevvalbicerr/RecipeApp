using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RecipeApp.Core.ViewModels.UpdateViewModels
{
	public class UserUpdateViewModel
	{
        public string Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz!")]
		[Display(Name = "Kullanıcı Adı")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Ad-Soyad boş bırakılamaz!")]
		[Display(Name = "Ad-Soyad")]
		public string FullName { get; set; }

		[EmailAddress(ErrorMessage = "Email Formatı yanlış")]
		[Required(ErrorMessage = "Email boş bırakılamaz!")]
		[Display(Name = "Email")]
		public string Email { get; set; }

		[Display(Name = "Telefon Numarası")]
		public string PhoneNumber { get; set; }

	}
}
