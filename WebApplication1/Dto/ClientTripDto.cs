using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto;

public class ClientTripDto(
)
{
    //in exercise descriptions there is also tripId + tripName in request body, but they don't make sens in reqeust body
    [Required] [StringLength(120)] public string FirstName { get; set; }
    [Required] [StringLength(120)] public string LastName { get; set; }
    [Required] [EmailAddress] public string Email { get; set; }
    [Required] [StringLength(120)] public string Telephone { get; set; }
    [Required] [StringLength(120)] public string Pesel { get; set; }
    public DateTime? PaymentDate { get; set; }
}