using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[Route("/api/trips")]
[ApiController]
public class TripsController(TripsContext context) : ControllerBase
{
    [HttpGet]
    public IActionResult GetTrips(int page = 0, int pageSize = 10)
    {
        var trips = context.Trips
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

        var allTripsCount = context.Trips.Count();

        var pageWrapper = new Page<TripDto>(
            page, pageSize, (int)Math.Ceiling(allTripsCount / (double)pageSize), trips
        );
        return Ok(pageWrapper);
    }

    [HttpPost("{tripId:int}/clients")]
    public IActionResult AssignClientToTrip(int tripId, ClientTripDto request)
    {
        //imo there is an issue in exercise description - point 1. and message body suggest that the endpoint should create client resources but point 2. suggest that it should not. 
        //I assume that the endpoint creates client and there can be only one client with given pesel in system so validation from point 2. can be skipped + unique constraint on db can be added

        if (context.Clients.FirstOrDefault(c => c.Pesel == request.Pesel) != null)
        {
            return BadRequest("Client with given pesel already exist");
        }

        var clientEntity = new Client()
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Pesel = request.Pesel,
            Telephone = request.Telephone
        };
        context.Clients.Add(clientEntity);
        
        var trip = context.Trips.FirstOrDefault(t => t.IdTrip == tripId);
        if (trip == null)
        {
            return BadRequest("Trip with given id doesn't exist");
        }
        if (trip.DateFrom > DateTime.Now)
        {
            return BadRequest("Given trip already started");
        }

        if (context.ClientTrips.FirstOrDefault(t => t.IdClient == context.Clients.FirstOrDefault(c => c.Pesel == request.Pesel).IdClient && t.IdTrip == tripId) != null)
        {
            return BadRequest("The client is already assigned to the trip");
        }

        var entity = new ClientTrip
        {
            IdClientNavigation = clientEntity,
            IdTrip = trip.IdTrip,
            PaymentDate = request.PaymentDate,
            RegisteredAt = DateTime.Now
        };

        context.ClientTrips.Add(entity);
        context.SaveChanges();
        return Created();
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
}