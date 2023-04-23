using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eserProje.Models
{
    public class MainCategory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MainCategoryID { get; set; }


        [Required(ErrorMessage = "{0} boş olamaz "), Display(Name = "Ana Kategori Adı"), StringLength(40, MinimumLength = 2, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string MainCategoryName { get; set; }
    }
}