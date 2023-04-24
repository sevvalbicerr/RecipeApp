using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeApp.Dal.Migrations
{
    /// <inheritdoc />
    public partial class AddseedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Çorbalar" },
                    { 2, "Kebaplar" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Image", "Name", "Score", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 4, 24, 15, 57, 41, 593, DateTimeKind.Local).AddTicks(3775), "Domates çorbası yapmak için yağ ve un bir tencerede hafifçe kavrulur.Diğer taraftan kabuğu çıkarılıp, küp küp kesilmiş domates robottan geçirilip bu karışıma ilave edilir, birkaç dakika kavrulur.Ara verilmeden bir litre  kadar su ilave edilip karıştırma işlemini sürdürülür. 15 dakika bu şekilde kaynatılır.Daha sonra süt ilave edilip birkaç dakika daha kaynatılarak tuzu ilave edilip ocaktan alınır.Arzuya göre servis yaparken üzerine kaşar peyniri rendesi ilave edilir. Domates çorbamız servise hazır, afiyet olsun.", "xxxx", "Domates Çorbası", 0, "bc0dea57-68c0-4e92-80db-31b948351fca" },
                    { 2, 2, new DateTime(2023, 4, 24, 15, 57, 41, 593, DateTimeKind.Local).AddTicks(3790), "İlk olarak soğanı ve kapya biberi rondodan geçirin ya da ince ince doğrayın.Suyunu iyice sıkın.Kıymanın içerisine ekleyin.Tuz ve karabiberi de ekleyip güzelce yoğuralım ve dinlenmesi için dolaba kaldıralım.Bu sıra da lavaş için un hariç bütün malzemeleri derin bir kap içerisine alalım.Unu kontrollü ekleyip kıvamlı bir hamur yoğuralım yarım saat kadar mayalansın.Mayalanan hamuru 10-12 eşit parçaya bölelim.Her bir parçayı yuvarlak açıp tava da arkalı önlü pişirelim.Pişen lavaşları bir bez ya da örtüyle güzelce saralım.Dinlenen kıymayı yumruk büyüklüğünde parçalar alıp şişe geçirelim. Şiş yoksa tahta çubuklara geçirelim.Kebap şeklini verip döküm tava da yada normal tava da pişirelim.Lavaş ekmeği arasında domates, biber soğanla servis edelim. Deneyenlere afiyet olsun 🌿.", "zzzz", "Adana Kebap", 0, "ce51b864-2524-4466-b8db-3f98d3637992" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Amount", "Name", "RecipeId", "Unit" },
                values: new object[,]
                {
                    { 1, 1m, "Domates", 1, "adet" },
                    { 2, 1m, "Tuz", 1, "kaşık" },
                    { 3, 200m, "Et", 2, "gram" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
