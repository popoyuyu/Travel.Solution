using System.ComponentModel.DataAnnotations;
namespace Travel.Models
{
  public class Destination
  {
    public int DestinationId { get; set; }
    // [Required]
    // [StringLength(20)]
    // public string User { get; set; }
    [Required]
    [StringLength(20)]
    public string Country { get; set; }
    [Required]
    [StringLength(20)]
    public string City { get; set; }
    [Required]
    [Range(0, 10, ErrorMessage = "Rating must be betwen 0 and 10")]
    public int Rating { get; set; }
    [Required]
    public string Review { get; set; }
  }
}