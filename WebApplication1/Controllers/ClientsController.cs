using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;

namespace WebApplication1.Controllers;

[Route("/api")]
[ApiController]
public class ClientsController(TripsContext context) : ControllerBase
{
    private readonly TripsContext _context = context;
    
    
}