using System.ComponentModel.DataAnnotations;

namespace FrontToBack.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required]
        public int Offer { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required, MaxLength(200)]
        public string Image { get; set; }
    }
}
