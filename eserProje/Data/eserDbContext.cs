using eserProje.Models;
using Microsoft.EntityFrameworkCore;

namespace eserProje.Data
{
    public class eserDbContext : DbContext
    {
        public eserDbContext(DbContextOptions<eserDbContext> options) : base(options) { }

        public DbSet<Userr> Userrs { get; set; }
        public DbSet<Rolee> Rolees { get; set; }
        public DbSet<Likee> Likees { get; set; }

        public DbSet<Cloth> Clothes { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<MainCategory> MainCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rolee>().HasData(
                                                    new Rolee { RoleeID = 1, RoleeName = "Candidate" },
                                                    new Rolee { RoleeID = 2, RoleeName = "Client" },
                                                    new Rolee { RoleeID = 3, RoleeName = "Admin" },
                                                    new Rolee { RoleeID = 4, RoleeName = "Owner" },
                                                    new Rolee { RoleeID = 5, RoleeName = "Supervisor" }
                                                );

            modelBuilder.Entity<Userr>().HasData(
                                                    new Userr { UserrID = 1, RoleeID = 2, Password = "12345678", RePassword = "12345678", Email = "abc@hotmail.com" },
                                                    new Userr { UserrID = 2, RoleeID = 1, Password = "12345678", RePassword = "12345678", Email = "xyz@hotmail.com" },
                                                    new Userr { UserrID = 3, RoleeID = 5, Password = "12345678", RePassword = "12345678", Email = "aliveli@hotmail.com" },
                                                    new Userr { UserrID = 4, RoleeID = 3, Password = "123123123", RePassword = "123123123", Email = "admin@admin.com" }

                                                );

            modelBuilder.Entity<Likee>().HasData(
                                                     new Likee { LikeeID = 1, ClothID = 1 ,UserrID = 2, LikeeDate = Convert.ToDateTime("23.06.2022 08:15") },
                                                     new Likee { LikeeID = 2, ClothID = 3, UserrID = 2, LikeeDate = Convert.ToDateTime("23.06.2022 09:15") },
                                                     new Likee { LikeeID = 3, ClothID = 2, UserrID = 2, LikeeDate = Convert.ToDateTime("23.06.2022 11:10") },
                                                     new Likee { LikeeID = 4, ClothID = 3, UserrID = 1, LikeeDate = Convert.ToDateTime("23.06.2022 11:12") },
                                                     new Likee { LikeeID = 5, ClothID = 2, UserrID = 1, LikeeDate = Convert.ToDateTime("23.06.2022 11:01") }
                                                );
            modelBuilder.Entity<MainCategory>().HasData(
                                                     new MainCategory { MainCategoryID = 1, MainCategoryName = "Üst Giyim" },
                                                     new MainCategory { MainCategoryID = 2, MainCategoryName = "Dış Giyim" },
                                                     new MainCategory { MainCategoryID = 3, MainCategoryName = "Alt Giyim" }
                                                );

            modelBuilder.Entity<Category>().HasData(
                                                     new Category { CategoryID = 1, CategoryName = "Abiye", MainCategoryID=1 },
                                                     new Category { CategoryID = 2, CategoryName = "Elbise", MainCategoryID = 1 },
                                                     new Category { CategoryID = 3, CategoryName = "Takım", MainCategoryID = 1 },
                                                     new Category { CategoryID = 4, CategoryName = "Tulum", MainCategoryID = 1 },
                                                     new Category { CategoryID = 5, CategoryName = "Bluz", MainCategoryID = 1 },
                                                     new Category { CategoryID = 6, CategoryName = "Gömlek", MainCategoryID = 1 },
                                                     new Category { CategoryID = 7, CategoryName = "T-Shirt", MainCategoryID = 1 },

                                                     new Category { CategoryID = 8, CategoryName = "Ceket", MainCategoryID = 2 },
                                                     new Category { CategoryID = 9, CategoryName = "Trençkot", MainCategoryID = 2 },
                                                     new Category { CategoryID = 10, CategoryName = "Yelek", MainCategoryID = 2 },
                                                     new Category { CategoryID = 11, CategoryName = "Kot Ceket", MainCategoryID = 2 },
                                                     new Category { CategoryID = 12, CategoryName = "Mont Kaban", MainCategoryID = 2 },

                                                     new Category { CategoryID = 13, CategoryName = "Pantolon", MainCategoryID = 3 },
                                                     new Category { CategoryID = 14, CategoryName = "Jean Pantolon", MainCategoryID = 3 },
                                                     new Category { CategoryID = 15, CategoryName = "Etek", MainCategoryID = 3 },
                                                     new Category { CategoryID = 16, CategoryName = "Tayt", MainCategoryID = 3 },
                                                     new Category { CategoryID = 17, CategoryName = "Eşofman", MainCategoryID = 3 },
                                                     new Category { CategoryID = 18, CategoryName = "Şort", MainCategoryID = 3 }
                                                );



            modelBuilder.Entity<Cloth>().HasData(
                                                     new Cloth { ClothID = 1, ClothName = "Tek Omuz Uzun Abiye - KIRMIZI", Price = Convert.ToDecimal(649.99), Description = "Dummy Text", CategoryID = 1 },
                                                     new Cloth { ClothID = 2, ClothName = "Yırtmaç Fırfır Tek Omuz Abiye - KIRMIZI", Price = Convert.ToDecimal(699.99), Description = "Dummy Text", CategoryID = 1 },
                                                     new Cloth { ClothID = 3, ClothName = "Göğüs Detay Simli Uzun Abiye - KIRMIZI", Price = Convert.ToDecimal(649.99), Description = "Dummy Text", CategoryID = 1 },

                                                     new Cloth { ClothID = 4, ClothName = "Anvelop Yaka Renkli Midi Elbise - PEMBE", Price = Convert.ToDecimal(242.99), Description = "Dummy Text", CategoryID = 2 },
                                                     new Cloth { ClothID = 5, ClothName = "Mini Yırtmaçlı Elbise - SİYAH", Price = Convert.ToDecimal(144.99), Description = "Dummy Text", CategoryID = 2 },
                                                     new Cloth { ClothID = 6, ClothName = "İri Çiçek Sıfır Kol Midi Elbise - EKRU", Price = Convert.ToDecimal(139.99), Description = "Dummy Text", CategoryID = 2 },

                                                     new Cloth { ClothID = 7, ClothName = "Oversize Keten Takım - YAĞ YEŞİLİ", Price = Convert.ToDecimal(427.49), Description = "Dummy Text", CategoryID = 3 },
                                                     new Cloth { ClothID = 8, ClothName = "Ceket Pantolon Takım - KIRMIZI", Price = Convert.ToDecimal(719.99), Description = "Dummy Text", CategoryID = 3 },
                                                     new Cloth { ClothID = 9, ClothName = "Ceket Pantolon Takım - SİYAH", Price = Convert.ToDecimal(719.99), Description = "Dummy Text", CategoryID = 3 },

                                                     new Cloth { ClothID = 10, ClothName = "Bol Paça Ayrobin Tulum - SİYAH", Price = Convert.ToDecimal(215.99), Description = "Dummy Text", CategoryID = 4 },
                                                     new Cloth { ClothID = 11, ClothName = "Kol Fırfır Klasik Tulum - SİYAH", Price = Convert.ToDecimal(269.99), Description = "Dummy Text", CategoryID = 4 },
                                                     new Cloth { ClothID = 12, ClothName = "Bel Dekolteli Tulum - YAĞ YEŞİLİ", Price = Convert.ToDecimal(819.99), Description = "Dummy Text", CategoryID = 4 },

                                                     new Cloth { ClothID = 13, ClothName = "Vatkalı Degaje Bluz - BEYAZ", Price = Convert.ToDecimal(149.99), Description = "Dummy Text", CategoryID = 5 },
                                                     new Cloth { ClothID = 14, ClothName = "Vatkalı Degaje Bluz - SİYAH", Price = Convert.ToDecimal(149.99), Description = "Dummy Text", CategoryID = 5 },
                                                     new Cloth { ClothID = 15, ClothName = "Kare Yaka Yan Bağcıklı Bluz - BEJ", Price = Convert.ToDecimal(139.99), Description = "Dummy Text", CategoryID = 5 },

                                                     new Cloth { ClothID = 16, ClothName = "Kuşaklı Ekose Gömlek - LİLA", Price = Convert.ToDecimal(84.99), Description = "Dummy Text", CategoryID = 6 },
                                                     new Cloth { ClothID = 17, ClothName = "Oversize Salaş Gömlek - BEYAZ", Price = Convert.ToDecimal(206.99), Description = "Dummy Text", CategoryID = 6 },
                                                     new Cloth { ClothID = 18, ClothName = "Tek Cep Oversize Gömlek - YEŞİL", Price = Convert.ToDecimal(179.99), Description = "Dummy Text", CategoryID = 6 },

                                                     new Cloth { ClothID = 19, ClothName = "Vatkalı Düz T-Shirt - BEYAZ", Price = Convert.ToDecimal(99.99), Description = "Dummy Text", CategoryID = 7 },
                                                     new Cloth { ClothID = 20, ClothName = "V Yaka Kısa Kollu T-Shirt - BEYAZ", Price = Convert.ToDecimal(119.99), Description = "Dummy Text", CategoryID = 7 },
                                                     new Cloth { ClothID = 21, ClothName = "Kol Kat Yan Yırtmaçlı T-Shirt - SİYAH", Price = Convert.ToDecimal(119.99), Description = "Dummy Text", CategoryID = 7 },



                                                     new Cloth { ClothID = 22, ClothName = "Gizli Cep Vatkalı Blazer Ceket - CAMEL", Price = Convert.ToDecimal(517.49), Description = "Dummy Text", CategoryID = 8 },
                                                     new Cloth { ClothID = 23, ClothName = "Atlas Kumaş Blazer Ceket - SAKS", Price = Convert.ToDecimal(517.49), Description = "Dummy Text", CategoryID = 8 },
                                                     new Cloth { ClothID = 24, ClothName = "Kruvaze Yaka Blazer Ceket - CAMEL", Price = Convert.ToDecimal(517.49), Description = "Dummy Text", CategoryID = 8 },

                                                     new Cloth { ClothID = 25, ClothName = "Kadife Yaka Cepli Trençkot - TAŞ", Price = Convert.ToDecimal(607.49), Description = "Dummy Text", CategoryID = 9 },
                                                     new Cloth { ClothID = 26, ClothName = "Garnili Trençkot - BEJ", Price = Convert.ToDecimal(737.99), Description = "Dummy Text", CategoryID = 9 },
                                                     new Cloth { ClothID = 27, ClothName = "Kadife Yaka Cepli Trençkot - HAKİ", Price = Convert.ToDecimal(607.49), Description = "Dummy Text", CategoryID = 9 },

                                                     new Cloth { ClothID = 28, ClothName = "Garnili Şişme Yelek - HAKİ", Price = Convert.ToDecimal(494.99), Description = "Dummy Text", CategoryID = 10 },
                                                     new Cloth { ClothID = 29, ClothName = "Şişme Yelek - SİYAH", Price = Convert.ToDecimal(449.99), Description = "Dummy Text", CategoryID = 10 },
                                                     new Cloth { ClothID = 30, ClothName = "Gizli Fermuarlı Şişme Yelek - SİYAH", Price = Convert.ToDecimal(449.99), Description = "Dummy Text", CategoryID = 10 },

                                                     new Cloth { ClothID = 31, ClothName = "Gold Fermuarlı Denim Ceket - FÜME", Price = Convert.ToDecimal(314.99), Description = "Dummy Text", CategoryID = 11 },
                                                     new Cloth { ClothID = 32, ClothName = "Gold Fermuarlı Denim Ceket - MAVİ", Price = Convert.ToDecimal(314.99), Description = "Dummy Text", CategoryID = 11 },
                                                     new Cloth { ClothID = 33, ClothName = "Kol Taş Detaylı Kot Ceket - FÜME", Price = Convert.ToDecimal(170.99), Description = "Dummy Text", CategoryID = 11 },

                                                     new Cloth { ClothID = 34, ClothName = "Dikiş Desen Mevsimlik Mont - HAKİ", Price = Convert.ToDecimal(499.99), Description = "Dummy Text", CategoryID = 12 },
                                                     new Cloth { ClothID = 35, ClothName = "Çiçek Nakışlı Mevsimlik Mont - BEYAZ", Price = Convert.ToDecimal(649.99), Description = "Dummy Text", CategoryID = 12 },
                                                     new Cloth { ClothID = 36, ClothName = "Kuşaklı Kaşe Kaban - CAMEL", Price = Convert.ToDecimal(1499.99), Description = "Dummy Text", CategoryID = 12 },



                                                     new Cloth { ClothID = 37, ClothName = "Cepli Palazzo Pantolon - BEJ", Price = Convert.ToDecimal(247.49), Description = "Dummy Text", CategoryID = 13 },
                                                     new Cloth { ClothID = 38, ClothName = "Cepli Palazzo Pantolon - SİYAH", Price = Convert.ToDecimal(247.49), Description = "Dummy Text", CategoryID = 13 },
                                                     new Cloth { ClothID = 39, ClothName = "Yüksek Bel Kemerli Kumaş Pantolon - SİYAH", Price = Convert.ToDecimal(224.99), Description = "Dummy Text", CategoryID = 13 },

                                                     new Cloth { ClothID = 40, ClothName = "Yüksekbel Skinny Pantolon - SİYAH", Price = Convert.ToDecimal(149.99), Description = "Dummy Text", CategoryID = 14 },
                                                     new Cloth { ClothID = 41, ClothName = "Yüksekbel Skinny Pantolon - LACİVERT", Price = Convert.ToDecimal(149.99), Description = "Dummy Text", CategoryID = 14 },
                                                     new Cloth { ClothID = 42, ClothName = "Skinny Fit Jean - MAVİ", Price = Convert.ToDecimal(174.99), Description = "Dummy Text", CategoryID = 14 },

                                                     new Cloth { ClothID = 43, ClothName = "Yırtmaçlı Saten Etek - SİYAH", Price = Convert.ToDecimal(233.99), Description = "Dummy Text", CategoryID = 15 },
                                                     new Cloth { ClothID = 44, ClothName = "Kruvaze Midi Etek - SİYAH", Price = Convert.ToDecimal(224.99), Description = "Dummy Text", CategoryID = 15 },
                                                     new Cloth { ClothID = 45, ClothName = "Yan Yırtmaçlı Midi Etek - KREM", Price = Convert.ToDecimal(149.99), Description = "Dummy Text", CategoryID = 15 },

                                                     new Cloth { ClothID = 46, ClothName = "Korse Etkili Tayt - MÜRDÜM", Price = Convert.ToDecimal(129.99), Description = "Dummy Text", CategoryID = 16 },
                                                     new Cloth { ClothID = 47, ClothName = "İspanyol Paça Fitilli Tayt - FÜME", Price = Convert.ToDecimal(139.99), Description = "Dummy Text", CategoryID = 16 },
                                                     new Cloth { ClothID = 48, ClothName = "İspanyol Paça Fitilli Tayt - BEJ", Price = Convert.ToDecimal(139.99), Description = "Dummy Text", CategoryID = 16 },

                                                     new Cloth { ClothID = 49, ClothName = "Paça Lastik Eşofman - SİYAH", Price = Convert.ToDecimal(179.99), Description = "Dummy Text", CategoryID = 17 },
                                                     new Cloth { ClothID = 50, ClothName = "Paça Lastik Eşofman - GRİ", Price = Convert.ToDecimal(179.99), Description = "Dummy Text", CategoryID = 17 },
                                                     new Cloth { ClothID = 51, ClothName = "Bol Paça Eşofman - GRİ", Price = Convert.ToDecimal(124.99), Description = "Dummy Text", CategoryID = 17 },

                                                     new Cloth { ClothID = 52, ClothName = "Yüksek Bel Denim Şort - MAVİ", Price = Convert.ToDecimal(179.99), Description = "Dummy Text", CategoryID = 18 },
                                                     new Cloth { ClothID = 53, ClothName = "Palazzo Şort - SARI", Price = Convert.ToDecimal(134.99), Description = "Dummy Text", CategoryID = 18 },
                                                     new Cloth { ClothID = 54, ClothName = "Palazzo Şort - PEMBE", Price = Convert.ToDecimal(134.99), Description = "Dummy Text", CategoryID = 18 }


                                                );


        }
    }
}
