using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eserProje.Migrations
{
    public partial class bir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainCategories",
                columns: table => new
                {
                    MainCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCategoryName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategories", x => x.MainCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Rolees",
                columns: table => new
                {
                    RoleeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rolees", x => x.RoleeID);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    MainCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                    table.ForeignKey(
                        name: "FK_Categories_MainCategories_MainCategoryID",
                        column: x => x.MainCategoryID,
                        principalTable: "MainCategories",
                        principalColumn: "MainCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Userrs",
                columns: table => new
                {
                    UserrID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(52)", maxLength: 52, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RoleeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userrs", x => x.UserrID);
                    table.ForeignKey(
                        name: "FK_Userrs_Rolees_RoleeID",
                        column: x => x.RoleeID,
                        principalTable: "Rolees",
                        principalColumn: "RoleeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clothes",
                columns: table => new
                {
                    ClothID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClothName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(6,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clothes", x => x.ClothID);
                    table.ForeignKey(
                        name: "FK_Clothes_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likees",
                columns: table => new
                {
                    LikeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserrID = table.Column<int>(type: "int", nullable: false),
                    ClothID = table.Column<int>(type: "int", nullable: false),
                    LikeeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likees", x => x.LikeeID);
                    table.ForeignKey(
                        name: "FK_Likees_Clothes_ClothID",
                        column: x => x.ClothID,
                        principalTable: "Clothes",
                        principalColumn: "ClothID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likees_Userrs_UserrID",
                        column: x => x.UserrID,
                        principalTable: "Userrs",
                        principalColumn: "UserrID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MainCategories",
                columns: new[] { "MainCategoryID", "MainCategoryName" },
                values: new object[,]
                {
                    { 1, "Üst Giyim" },
                    { 2, "Dış Giyim" },
                    { 3, "Alt Giyim" }
                });

            migrationBuilder.InsertData(
                table: "Rolees",
                columns: new[] { "RoleeID", "RoleeName" },
                values: new object[,]
                {
                    { 1, "Candidate" },
                    { 2, "Client" },
                    { 3, "Admin" },
                    { 4, "Owner" },
                    { 5, "Supervisor" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "MainCategoryID" },
                values: new object[,]
                {
                    { 1, "Abiye", 1 },
                    { 2, "Elbise", 1 },
                    { 3, "Takım", 1 },
                    { 4, "Tulum", 1 },
                    { 5, "Bluz", 1 },
                    { 6, "Gömlek", 1 },
                    { 7, "T-Shirt", 1 },
                    { 8, "Ceket", 2 },
                    { 9, "Trençkot", 2 },
                    { 10, "Yelek", 2 },
                    { 11, "Kot Ceket", 2 },
                    { 12, "Mont Kaban", 2 },
                    { 13, "Pantolon", 3 },
                    { 14, "Jean Pantolon", 3 },
                    { 15, "Etek", 3 },
                    { 16, "Tayt", 3 },
                    { 17, "Eşofman", 3 },
                    { 18, "Şort", 3 }
                });

            migrationBuilder.InsertData(
                table: "Userrs",
                columns: new[] { "UserrID", "Email", "Password", "RoleeID" },
                values: new object[,]
                {
                    { 1, "abc@hotmail.com", "12345678", 2 },
                    { 2, "xyz@hotmail.com", "12345678", 1 },
                    { 3, "aliveli@hotmail.com", "12345678", 5 },
                    { 4, "admin@admin.com", "123123123", 3 }
                });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "ClothID", "CategoryID", "ClothName", "Description", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Tek Omuz Uzun Abiye - KIRMIZI", "Dummy Text", 649.99m },
                    { 2, 1, "Yırtmaç Fırfır Tek Omuz Abiye - KIRMIZI", "Dummy Text", 699.99m },
                    { 3, 1, "Göğüs Detay Simli Uzun Abiye - KIRMIZI", "Dummy Text", 649.99m },
                    { 4, 2, "Anvelop Yaka Renkli Midi Elbise - PEMBE", "Dummy Text", 242.99m },
                    { 5, 2, "Mini Yırtmaçlı Elbise - SİYAH", "Dummy Text", 144.99m },
                    { 6, 2, "İri Çiçek Sıfır Kol Midi Elbise - EKRU", "Dummy Text", 139.99m },
                    { 7, 3, "Oversize Keten Takım - YAĞ YEŞİLİ", "Dummy Text", 427.49m },
                    { 8, 3, "Ceket Pantolon Takım - KIRMIZI", "Dummy Text", 719.99m },
                    { 9, 3, "Ceket Pantolon Takım - SİYAH", "Dummy Text", 719.99m },
                    { 10, 4, "Bol Paça Ayrobin Tulum - SİYAH", "Dummy Text", 215.99m },
                    { 11, 4, "Kol Fırfır Klasik Tulum - SİYAH", "Dummy Text", 269.99m },
                    { 12, 4, "Bel Dekolteli Tulum - YAĞ YEŞİLİ", "Dummy Text", 819.99m },
                    { 13, 5, "Vatkalı Degaje Bluz - BEYAZ", "Dummy Text", 149.99m },
                    { 14, 5, "Vatkalı Degaje Bluz - SİYAH", "Dummy Text", 149.99m },
                    { 15, 5, "Kare Yaka Yan Bağcıklı Bluz - BEJ", "Dummy Text", 139.99m },
                    { 16, 6, "Kuşaklı Ekose Gömlek - LİLA", "Dummy Text", 84.99m },
                    { 17, 6, "Oversize Salaş Gömlek - BEYAZ", "Dummy Text", 206.99m },
                    { 18, 6, "Tek Cep Oversize Gömlek - YEŞİL", "Dummy Text", 179.99m },
                    { 19, 7, "Vatkalı Düz T-Shirt - BEYAZ", "Dummy Text", 99.99m },
                    { 20, 7, "V Yaka Kısa Kollu T-Shirt - BEYAZ", "Dummy Text", 119.99m },
                    { 21, 7, "Kol Kat Yan Yırtmaçlı T-Shirt - SİYAH", "Dummy Text", 119.99m },
                    { 22, 8, "Gizli Cep Vatkalı Blazer Ceket - CAMEL", "Dummy Text", 517.49m },
                    { 23, 8, "Atlas Kumaş Blazer Ceket - SAKS", "Dummy Text", 517.49m },
                    { 24, 8, "Kruvaze Yaka Blazer Ceket - CAMEL", "Dummy Text", 517.49m },
                    { 25, 9, "Kadife Yaka Cepli Trençkot - TAŞ", "Dummy Text", 607.49m },
                    { 26, 9, "Garnili Trençkot - BEJ", "Dummy Text", 737.99m },
                    { 27, 9, "Kadife Yaka Cepli Trençkot - HAKİ", "Dummy Text", 607.49m },
                    { 28, 10, "Garnili Şişme Yelek - HAKİ", "Dummy Text", 494.99m },
                    { 29, 10, "Şişme Yelek - SİYAH", "Dummy Text", 449.99m },
                    { 30, 10, "Gizli Fermuarlı Şişme Yelek - SİYAH", "Dummy Text", 449.99m },
                    { 31, 11, "Gold Fermuarlı Denim Ceket - FÜME", "Dummy Text", 314.99m },
                    { 32, 11, "Gold Fermuarlı Denim Ceket - MAVİ", "Dummy Text", 314.99m },
                    { 33, 11, "Kol Taş Detaylı Kot Ceket - FÜME", "Dummy Text", 170.99m },
                    { 34, 12, "Dikiş Desen Mevsimlik Mont - HAKİ", "Dummy Text", 499.99m },
                    { 35, 12, "Çiçek Nakışlı Mevsimlik Mont - BEYAZ", "Dummy Text", 649.99m },
                    { 36, 12, "Kuşaklı Kaşe Kaban - CAMEL", "Dummy Text", 1499.99m },
                    { 37, 13, "Cepli Palazzo Pantolon - BEJ", "Dummy Text", 247.49m },
                    { 38, 13, "Cepli Palazzo Pantolon - SİYAH", "Dummy Text", 247.49m },
                    { 39, 13, "Yüksek Bel Kemerli Kumaş Pantolon - SİYAH", "Dummy Text", 224.99m },
                    { 40, 14, "Yüksekbel Skinny Pantolon - SİYAH", "Dummy Text", 149.99m },
                    { 41, 14, "Yüksekbel Skinny Pantolon - LACİVERT", "Dummy Text", 149.99m },
                    { 42, 14, "Skinny Fit Jean - MAVİ", "Dummy Text", 174.99m }
                });

            migrationBuilder.InsertData(
                table: "Clothes",
                columns: new[] { "ClothID", "CategoryID", "ClothName", "Description", "Price" },
                values: new object[,]
                {
                    { 43, 15, "Yırtmaçlı Saten Etek - SİYAH", "Dummy Text", 233.99m },
                    { 44, 15, "Kruvaze Midi Etek - SİYAH", "Dummy Text", 224.99m },
                    { 45, 15, "Yan Yırtmaçlı Midi Etek - KREM", "Dummy Text", 149.99m },
                    { 46, 16, "Korse Etkili Tayt - MÜRDÜM", "Dummy Text", 129.99m },
                    { 47, 16, "İspanyol Paça Fitilli Tayt - FÜME", "Dummy Text", 139.99m },
                    { 48, 16, "İspanyol Paça Fitilli Tayt - BEJ", "Dummy Text", 139.99m },
                    { 49, 17, "Paça Lastik Eşofman - SİYAH", "Dummy Text", 179.99m },
                    { 50, 17, "Paça Lastik Eşofman - GRİ", "Dummy Text", 179.99m },
                    { 51, 17, "Bol Paça Eşofman - GRİ", "Dummy Text", 124.99m },
                    { 52, 18, "Yüksek Bel Denim Şort - MAVİ", "Dummy Text", 179.99m },
                    { 53, 18, "Palazzo Şort - SARI", "Dummy Text", 134.99m },
                    { 54, 18, "Palazzo Şort - PEMBE", "Dummy Text", 134.99m }
                });

            migrationBuilder.InsertData(
                table: "Likees",
                columns: new[] { "LikeeID", "ClothID", "LikeeDate", "UserrID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 6, 23, 8, 15, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, 3, new DateTime(2022, 6, 23, 9, 15, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 2, new DateTime(2022, 6, 23, 11, 10, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 4, 3, new DateTime(2022, 6, 23, 11, 12, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, 2, new DateTime(2022, 6, 23, 11, 1, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MainCategoryID",
                table: "Categories",
                column: "MainCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Clothes_CategoryID",
                table: "Clothes",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Likees_ClothID",
                table: "Likees",
                column: "ClothID");

            migrationBuilder.CreateIndex(
                name: "IX_Likees_UserrID",
                table: "Likees",
                column: "UserrID");

            migrationBuilder.CreateIndex(
                name: "IX_Userrs_RoleeID",
                table: "Userrs",
                column: "RoleeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likees");

            migrationBuilder.DropTable(
                name: "Clothes");

            migrationBuilder.DropTable(
                name: "Userrs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Rolees");

            migrationBuilder.DropTable(
                name: "MainCategories");
        }
    }
}
