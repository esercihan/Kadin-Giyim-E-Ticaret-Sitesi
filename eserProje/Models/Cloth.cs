using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eserProje.Models
{
    public class Cloth
    {
        [Key]
        public int ClothID { get; set; }

        [Required(ErrorMessage = "{0} boş olamaz "), Display(Name="Giysi"), StringLength(60, MinimumLength = 2, ErrorMessage ="{0} {2}-{1} karakter olmalı")]
        public string ClothName { get; set; }

        [Required(ErrorMessage ="{0} boş olamaz "), Display(Name="Fiyat"), DataType(DataType.Currency),Column(TypeName ="decimal(6, 2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "{0} boş olamaz "), Display(Name="Açıklama"), StringLength(600,MinimumLength = 2, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} boş olamaz "), Display(Name = "Kategori")]
         public int CategoryID { get; set; }

       




        //Navigation
        public Category Category { get; set; }

       

       


    }
}
