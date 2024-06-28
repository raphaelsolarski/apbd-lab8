using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;
using WebApplication1.Utils;

namespace WebApplication1.Repository;

public class TripsRepository(TripsContext context) : ITripsRepository
{
    public Page<Trip> GetTrips(int page, int pageSize)
    {
        var trips = context.Trips
            .Include(p => p.IdCountries)
            .Include("ClientTrips.IdClientNavigation")
            .OrderByDescending(t => t.DateFrom)
            .Skip(page * pageSize)
            .Take(pageSize)
            .ToList();

        var allTripsCount = context.Trips.Count();

        var pageWrapper = new Page<Trip>(
            page, pageSize, (int)Math.Ceiling(allTripsCount / (double)pageSize), trips
        );
        return pageWrapper;
    }

    public Trip? FindTripById(int id)
    {
        return context.Trips.FirstOrDefault(t => t.IdTrip == id);
    }

    public void CreateClientAssignedToTrip(Client client, ClientTrip clientTrip)
    {
        context.Clients.Add(client);
        clientTrip.IdClientNavigation = client;
        context.ClientTrips.Add(clientTrip);
        context.SaveChanges();
    }
}