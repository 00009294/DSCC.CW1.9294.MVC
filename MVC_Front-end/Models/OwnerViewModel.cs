using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Front_end.Models
{
    public class OwnerViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("OwnerName")]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        public int CarId { get; set; }
    }
}