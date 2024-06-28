using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Repository;

public class ClientsRepository(TripsContext context) : IClientsRepository
{
    public Client? FindClientWithTrips(int id)
    {
        return context.Clients
            .Include(c => c.ClientTrips)
            .FirstOrDefault(c => c.IdClient == id);
    }

    public Client? FindClientByPesel(string pesel)
    {
        return context.Clients.FirstOrDefault(c => c.Pesel == pesel);
    }
    
    public void DeleteClient(int id)
    {
        var client = FindClientWithTrips(id);
        if (client != null)
        {
            context.Remove(client);
            context.SaveChanges();
        }
    }
    
}