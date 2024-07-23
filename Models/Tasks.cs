using System.ComponentModel.DataAnnotations;

namespace AutoMekanikV3Final.Models
{
    public class Tasks
    {
        [Key]
        public int Numri { get; set; }
        public string Task { get; set; }
        public string Time { get; set; }
    }
}
