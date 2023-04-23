using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eserProje.Models
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryID { get; set; }


        [Required(ErrorMessage = "{0} boş olamaz "), Display(Name ="Kategori Adı"), StringLength(40, MinimumLength = 2, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "{0} boş olamaz "), Display(Name = "Ana Kategori")]
        public int MainCategoryID { get; set; }






        //Navigation
        public MainCategory MainCategory { get; set; }
    }
}