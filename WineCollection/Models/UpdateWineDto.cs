using System.ComponentModel.DataAnnotations;

namespace WineCollection.Models
{
    public class UpdateWineDto
    {

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string TasteDescription { get; set; }
        public decimal Price { get; set; }
        public int Year { get; set; }
        public string ImgPath { get; set; }
        public string Style { get; set; }
        public decimal ServingTemperature { get; set; }
        public int ColorId { get; set; }
        public string GrapeVariety { get; set; }
        public string Vineyard { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }
}
