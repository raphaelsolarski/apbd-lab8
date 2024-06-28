using WebApplication1.Dto;
using WebApplication1.Utils;

namespace WebApplication1.Services;

public interface ITripsService
{
    Page<TripDto> GetTrips(int page, int pageSize);

    void AssignClientToTrip(int tripId, ClientTripDto clientTripDto);
}
public class UserWithGivenPeselExistsException() : Exception("Client with given pesel already exists");

public class TripDoesNotExistsException() : Exception("Trip with given id doesn't exist");

public class TripAlreadyStartedException() : Exception("Given trip already started");
