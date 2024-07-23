using AutoMekanikV3Final.Migrations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMekanikV3Final.Models
{
    public class Cars
    {
        [Key]
        public int Numri { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int? KategoriaNumri { get; set; }

    }
}
