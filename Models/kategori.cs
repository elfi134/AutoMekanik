using System.ComponentModel.DataAnnotations;

namespace AutoMekanikV3Final.Models
{
    public class kategori
    {
        [Key]
        public int Numri { get; set; }
        public string Titulli { get; set; }
    }
}
