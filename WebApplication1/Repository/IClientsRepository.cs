using WebApplication1.Models;

namespace WebApplication1.Repository;

public interface IClientsRepository
{
    Client? FindClientWithTrips(int id);
    
    Client? FindClientByPesel(string pesel);

    void DeleteClient(int id);
    
}
