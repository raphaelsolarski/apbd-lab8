namespace WebApplication1.Services;

public interface IClientsService
{
    void DeleteClient(int id);
}

public class CanNotDeleteClientWithExistingTripsException() : Exception("Client with existing trips can't be delete");