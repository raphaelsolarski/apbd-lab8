using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dto;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("/api/trips")]
    [ApiController]
    public class TripsController(ITripsService tripsService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetTrips(int page = 0, int pageSize = 10)
        {
            return Ok(tripsService.GetTrips(page, pageSize));
        }

        [HttpPost("{tripId:int}/clients")]
        public IActionResult AssignClientToTrip(int tripId, ClientTripDto request)
        {
            try
            {
                tripsService.AssignClientToTrip(tripId, request);
            }
            catch (Exception e)
            {
                if (e is TripAlreadyStartedException || e is TripDoesNotExistsException ||
                    e is UserWithGivenPeselExistsException)
                {
                    return BadRequest(e.Message);
                }

                throw new Exception("Unexpected during assinging client to trip", e);
            }

            return Created();
        }
    }
}