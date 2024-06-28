using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Context;

namespace WebApplication1.Controllers;

[Route("/api/clients")]
[ApiController]
public class ClientsController(TripsContext context) : ControllerBase
{
    private readonly TripsContext _context = context;
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteClient(int id)
    {
        var client = _context.Clients
            .Include(c => c.ClientTrips)
            .FirstOrDefault(c => c.IdClient == id);

        if (client != null)
        {
            if (!client.ClientTrips.IsNullOrEmpty())
            {
                return BadRequest("Client with existing trips can't be deleted");
            }
            _context.Remove(client);
            _context.SaveChanges();
        }
        
        return NoContent();
    }

    
}