using System.ComponentModel.DataAnnotations;

namespace FrontToBack.Areas.Admin.ViewModels
{
    public class SliderViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Offer { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required, MaxLength(200)]
        public IFormFile? Image { get; set; }
    }
}
