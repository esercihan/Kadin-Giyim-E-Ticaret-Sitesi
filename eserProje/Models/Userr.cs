using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eserProje.Models
{
    public class Userr
    {
        [Key]
        public int UserrID { get; set; }

        [Required(ErrorMessage = "{0} boş olamaz"), Display(Name = "E-posta"), StringLength(52, MinimumLength = 9, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string Email { get; set; }


        [Required(ErrorMessage = "{0} boş olamaz"), Display(Name = "Şifre"), StringLength(20, MinimumLength = 8, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} boş olamaz"),NotMapped, Compare("Password", ErrorMessage = "Şifre ve tekrarı uyuşmadı."), Display(Name = "Şifre tekrarı"), StringLength(20, MinimumLength = 8, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "{0} boş olamaz"), Display(Name = "Rol")]
        public int RoleeID { get; set; }

        //Navigation
        public Rolee Rolee { get; set; }
    }
}
