using Microsoft.IdentityModel.Tokens;
using WebApplication1.Repository;

namespace WebApplication1.Services;

public class ClientsService(IClientsRepository repository) : IClientsService
{
    public void DeleteClient(int id)
    {
        var client = repository.FindClientWithTrips(id);

        if (client != null)
        {
            if (!client.ClientTrips.IsNullOrEmpty())
            {
                throw new CanNotDeleteClientWithExistingTripsException();
            }

            repository.DeleteClient(id);
        }
    }
}