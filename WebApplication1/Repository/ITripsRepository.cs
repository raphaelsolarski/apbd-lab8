using WebApplication1.Models;
using WebApplication1.Utils;

namespace WebApplication1.Repository;

public interface ITripsRepository
{
    Page<Trip> GetTrips(int page, int pageSize);

    Trip? FindTripById(int id);

    void CreateClientAssignedToTrip(Client client, ClientTrip clientTrip);

}