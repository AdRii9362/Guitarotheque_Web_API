using System.ComponentModel.DataAnnotations;

namespace Guitarotheque_Web_API.Models.DTO
{
    public class GuitareImageDTO
    {
        [Required]
        public IFormFile GuitareImage { get; set; }

    }
}
