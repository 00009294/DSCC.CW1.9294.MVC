using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Front_end.Models
{
    public class CarViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("CarName")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Color { get; set; } = string.Empty;

        [Required]
        public bool IsUpgraded { get; set; }
    }
}