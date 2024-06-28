using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dto;

public class ClientTripDto(
    [Required] [StringLength(120)] string firstName,
    [Required] [StringLength(120)] string lastName,
    [Required] [EmailAddress] string email,
    [Required] [StringLength(120)] string telephone,
    [Required] [StringLength(120)] string pesel,
    DateTime paymentDate
)
{
    //in exercise descriptions there is also tripId + tripName in request body, but they don't make sens in reqeust body
    public string FirstName => firstName;
    public string LastName => lastName;
    public string Email => email;
    public string Telephone => telephone;
    public string Pesel => pesel;
    public DateTime PaymentDate => paymentDate;
}