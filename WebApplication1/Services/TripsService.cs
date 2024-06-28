using WebApplication1.Dto;
using WebApplication1.Models;
using WebApplication1.Repository;
using WebApplication1.Utils;

namespace WebApplication1.Services;

public class TripsService(ITripsRepository tripsRepository, IClientsRepository clientsRepository) : ITripsService
{
    public Page<TripDto> GetTrips(int page, int pageSize)
    {
        var entitiesPage = tripsRepository.GetTrips(page, pageSize);
        return new Page<TripDto>(
            entitiesPage.PageNum,
            entitiesPage.PageSize,
            entitiesPage.AllPages,
            entitiesPage.Content
                .Select(t => new TripDto(
                    t.Name,
                    t.Description,
                    t.DateFrom,
                    t.DateTo,
                    t.MaxPeople,
                    t.IdCountries.Select(c => new CountryDto(c.Name)).ToList(),
                    t.ClientTrips.Select(c =>
                            new ClientDto(c.IdClientNavigation.FirstName,
                                c.IdClientNavigation.LastName))
                        .ToList()
                ))
                .ToList()
        );
    }

    public void AssignClientToTrip(int tripId, ClientTripDto clientTripDto)
    {
        //imo there is an issue in exercise description - point 1. and message body suggest that the endpoint should create client resources but point 2. suggest that it should not. 
        //I assume that the endpoint creates client and there can be only one client with given pesel in system so validation from point 2. can be skipped + unique constraint on db can be added

        if (clientsRepository.FindClientByPesel(clientTripDto.Pesel) != null)
        {
            throw new UserWithGivenPeselExistsException();
        }
        
        var trip = tripsRepository.FindTripById(tripId);
        if (trip == null)
        {
            throw new TripDoesNotExistsException();
        }

        if (trip.DateFrom > DateTime.Now)
        {
            throw new TripAlreadyStartedException();
        }

        tripsRepository.CreateClientAssignedToTrip(new Client()
        {
            Email = clientTripDto.Email,
            FirstName = clientTripDto.FirstName,
            LastName = clientTripDto.LastName,
            Pesel = clientTripDto.Pesel,
            Telephone = clientTripDto.Telephone
        },
        new ClientTrip
        {
            IdTrip = trip.IdTrip,
            PaymentDate = clientTripDto.PaymentDate,
            RegisteredAt = DateTime.Now
        });
    }
}