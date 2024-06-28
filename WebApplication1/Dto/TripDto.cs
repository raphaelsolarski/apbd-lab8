using WebApplication1.Controllers;

namespace WebApplication1.Dto;

public class TripDto(
    string name,
    string description,
    DateTime dateFrom,
    DateTime dateTo,
    int maxPeople,
    ICollection<CountryDto> countries,
    ICollection<ClientDto> clients
)
{
    public string Name => name;
    public string Description => description;
    public DateTime DateFrom => dateFrom;
    public DateTime DateTo => dateTo;
    public int MaxPeople => maxPeople;
    public ICollection<CountryDto> Countries => countries;
    public ICollection<ClientDto> Clients => clients;
}