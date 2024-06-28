namespace WebApplication1.Dto;

public class ClientDto(
    string firstName,
    string lastName
)
{
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
}