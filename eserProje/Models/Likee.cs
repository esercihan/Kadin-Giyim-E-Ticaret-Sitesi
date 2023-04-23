using System.ComponentModel.DataAnnotations;

namespace eserProje.Models
{
    public class Likee
    {
        [Key]
        public int LikeeID { get; set; }

        [Required(ErrorMessage ="{0} boş olamaz "),Display(Name ="Kullanıcı")]
        public int UserrID { get; set; }

        [Required(ErrorMessage = "{0} boş olamaz "), Display(Name = "Giysi")]
        public int ClothID { get; set; }

        [Required(ErrorMessage ="{0} boş olamaz "),Display(Name ="Tarih"),DataType(DataType.DateTime)]
        public DateTime LikeeDate { get; set; }


        //Navigation
        public Userr Userr { get; set; }
        public Cloth Cloth { get; set; }
    }
}
