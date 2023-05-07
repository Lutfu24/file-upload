using System.ComponentModel.DataAnnotations;

namespace FrontToBack.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [MaxLength(100),Required]
        public string Title { get; set; }
        [MaxLength(500), Required]
        public string Description { get; set; }
    }
}
