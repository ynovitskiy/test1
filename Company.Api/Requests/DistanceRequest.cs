using System.ComponentModel.DataAnnotations;

namespace Company.Api.Requests
{
    public class DistanceRequest
    {
        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        public string From { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        public string To { get; set; }
    }
}
