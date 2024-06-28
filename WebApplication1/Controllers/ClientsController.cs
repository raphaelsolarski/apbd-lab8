using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("/api/clients")]
[ApiController]
public class ClientsController(IClientsService clientsService) : ControllerBase
{
    [HttpDelete("{id:int}")]
    public IActionResult DeleteClient(int id)
    {
        try
        {
            clientsService.DeleteClient(id);
            return NoContent();
        }
        catch (CanNotDeleteClientWithExistingTripsException e)
        {
            return BadRequest("Client with existing trips can't be deleted");
        }
    }
}