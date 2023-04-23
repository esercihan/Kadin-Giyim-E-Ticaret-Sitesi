using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eserProje.Models
{
    public class Rolee
    {

        [Key]
        public int RoleeID { get; set; }

        [Required(ErrorMessage = "{0} boş olamaz"), Display(Name = "Rol adı"), StringLength(20, MinimumLength = 2, ErrorMessage = "{0} {2}-{1} karakter olmalı")]
        public string RoleeName { get; set; }
    }
}