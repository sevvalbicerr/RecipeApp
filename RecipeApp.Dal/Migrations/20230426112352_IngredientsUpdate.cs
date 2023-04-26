﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeApp.Dal.Migrations
{
    /// <inheritdoc />
    public partial class IngredientsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

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

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Recipes");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { 1, 1, new DateTime(2023, 4, 25, 18, 11, 1, 542, DateTimeKind.Local).AddTicks(5388), "Domates çorbası yapmak için yağ ve un bir tencerede hafifçe kavrulur.Diğer taraftan kabuğu çıkarılıp, küp küp kesilmiş domates robottan geçirilip bu karışıma ilave edilir, birkaç dakika kavrulur.Ara verilmeden bir litre  kadar su ilave edilip karıştırma işlemini sürdürülür. 15 dakika bu şekilde kaynatılır.Daha sonra süt ilave edilip birkaç dakika daha kaynatılarak tuzu ilave edilip ocaktan alınır.Arzuya göre servis yaparken üzerine kaşar peyniri rendesi ilave edilir. Domates çorbamız servise hazır, afiyet olsun.", "data:image/jpeg;base64,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", "Domates Çorbası", 0, "4f7472cf-e2fb-4859-a03b-aa30f012ecc9" },
                    { 2, 2, new DateTime(2023, 4, 25, 18, 11, 1, 542, DateTimeKind.Local).AddTicks(5402), "İlk olarak soğanı ve kapya biberi rondodan geçirin ya da ince ince doğrayın.Suyunu iyice sıkın.Kıymanın içerisine ekleyin.Tuz ve karabiberi de ekleyip güzelce yoğuralım ve dinlenmesi için dolaba kaldıralım.Bu sıra da lavaş için un hariç bütün malzemeleri derin bir kap içerisine alalım.Unu kontrollü ekleyip kıvamlı bir hamur yoğuralım yarım saat kadar mayalansın.Mayalanan hamuru 10-12 eşit parçaya bölelim.Her bir parçayı yuvarlak açıp tava da arkalı önlü pişirelim.Pişen lavaşları bir bez ya da örtüyle güzelce saralım.Dinlenen kıymayı yumruk büyüklüğünde parçalar alıp şişe geçirelim. Şiş yoksa tahta çubuklara geçirelim.Kebap şeklini verip döküm tava da yada normal tava da pişirelim.Lavaş ekmeği arasında domates, biber soğanla servis edelim. Deneyenlere afiyet olsun 🌿.", "data:image/jpeg;base64,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", "Adana Kebap", 0, "665b852f-4863-4b92-8c4e-78ff83c330e1" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");
        }
    }
}
