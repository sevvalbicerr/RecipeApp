using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipeApp.Core.Models;
using RecipeApp.Service.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApp.Dal.Seeds
{
    public class RecipeSeed : IEntityTypeConfiguration<Recipe>
    {

        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            var imageData = ImageHelper.GetBytesFromImageUrl("https://cdn.yemek.com/mnresize/1250/833/uploads/2022/03/domates-corbasi-sevgililer-gunu-gorsel.jpg");
            builder.HasData(new Recipe()
            {
                 Id = 1,
                  CategoryId = 1,
                   CreatedDate = DateTime.Now,
                    Name = "Domates Çorbası",
                    Description= "Domates çorbası yapmak için yağ ve un bir tencerede hafifçe kavrulur.Diğer taraftan kabuğu çıkarılıp," +
                    " küp küp kesilmiş domates robottan geçirilip bu karışıma ilave edilir, birkaç dakika kavrulur.Ara verilmeden bir litre  " +
                    "kadar su ilave edilip karıştırma işlemini sürdürülür. 15 dakika bu şekilde kaynatılır." +
                    "Daha sonra süt ilave edilip birkaç dakika daha kaynatılarak tuzu ilave edilip ocaktan alınır." +
                    "Arzuya göre servis yaparken üzerine kaşar peyniri rendesi ilave edilir. Domates çorbamız servise hazır, afiyet olsun.",
                Image = imageData,
                UserId = "bc0dea57-68c0-4e92-80db-31b948351fca"


            },
            new Recipe()
            {
                 Id=2,
                 CategoryId = 2,
                 CreatedDate = DateTime.Now,
                 Name="Adana Kebap",
                 Description= "İlk olarak soğanı ve kapya biberi rondodan geçirin ya da ince ince doğrayın." +
                 "Suyunu iyice sıkın.Kıymanın içerisine ekleyin.Tuz ve karabiberi de ekleyip güzelce yoğuralım ve dinlenmesi için dolaba " +
                 "kaldıralım.Bu sıra da lavaş için un hariç bütün malzemeleri derin bir kap içerisine alalım." +
                 "Unu kontrollü ekleyip kıvamlı bir hamur yoğuralım yarım saat kadar mayalansın.Mayalanan hamuru 10-12 eşit parçaya bölelim." +
                 "Her bir parçayı yuvarlak açıp tava da arkalı önlü pişirelim.Pişen lavaşları bir bez ya da örtüyle güzelce saralım." +
                 "Dinlenen kıymayı yumruk büyüklüğünde parçalar alıp şişe geçirelim. Şiş yoksa tahta çubuklara geçirelim." +
                 "Kebap şeklini verip döküm tava da yada normal tava da pişirelim.Lavaş ekmeği arasında domates, biber soğanla servis edelim." +
                 " Deneyenlere afiyet olsun 🌿.",
                Image = imageData,
                UserId = "ce51b864-2524-4466-b8db-3f98d3637992"


            });
        }
    }
}
