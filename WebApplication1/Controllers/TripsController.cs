using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;

namespace WebApplication1.Controllers;

[Route("/api/trips")]
[ApiController]
public class TripsController(TripsContext context) : ControllerBase
{
    private readonly TripsContext _context = context;

    [HttpGet]
    public IActionResult GetTrips(int page = 0, int pageSize = 10)
    {
        var trips = _context.Trips
            .Include(p => p.IdCountries)
            .Include(p => p.ClientTrips)
            .Select(t => new TripDto(
                t.Name,
                t.Description,
                t.DateFrom,
                t.DateTo,
                t.MaxPeople,
                t.IdCountries.Select(c => new CountryDto(c.Name)).ToList(),
                t.ClientTrips.Select(c => new ClientDto(c.IdClientNavigation.FirstName, c.IdClientNavigation.LastName))
                    .ToList()
            ))
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();

        var allTripsCount = _context.Trips.Count();

        var pageWrapper = new Page<TripDto>(
            page, pageSize, (int)Math.Ceiling(allTripsCount / (double)pageSize), trips
        );
        return Ok(pageWrapper);
    }

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

    public class CountryDto(
        string name
    )
    {
        public string Name { get; } = name;
    }

    public class ClientDto(
        string firstName,
        string lastName
    )
    {
        public string FirstName { get; } = firstName;
        public string LastName { get; } = lastName;
    }

    public class Page<TV>(
        int pageNum,
        int pageSize,
        int allPages,
        ICollection<TV> content
    )
    {
        public int PageNum => pageNum;
        public int PageSize => pageSize;
        public int AllPages => allPages;
        public ICollection<TV> Content => content;
    }
}