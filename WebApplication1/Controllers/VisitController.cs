using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication1.Controllers;

[Route("api")]
[ApiController]
public class VisitController : ControllerBase
{
    // private readonly ClinicContext _context;
    //
    // public VisitController(ClinicContext context)
    // {
    //     _context = context;
    // }
    //
    // [HttpPost("/visits")]
    // public IActionResult PostVisit(CreateVisitRequest request)
    // {
    //     var patient = _context.Patients
    //         .Include(d => d.Visits)
    //         .SingleOrDefault(p => p.IdPatient == request.IdPatient);
    //     if (patient == null)
    //     {
    //         return BadRequest("Patient with given id does not exist");
    //     }
    //
    //     var doctor = _context.Doctors
    //         .Include(d => d.Visits)
    //         .Include(d => d.Schedules)
    //         .SingleOrDefault(p => p.IdDoctor == request.IdDoctor);
    //     if (doctor == null)
    //     {
    //         return BadRequest("Doctor with given id does not exist");
    //     }
    //
    //     if (!patient.Visits.Where(v => v.Date >= DateTime.Now).ToList().IsNullOrEmpty())
    //     {
    //         return BadRequest("Patient has visits in future");
    //     }
    //     
    //     var entity = new Visit()
    //     {
    //         IdDoctor = request.IdDoctor,
    //         IdPatient = request.IdPatient,
    //         Date = request.Date,
    //         Price = doctor.PriceForVisit
    //     };
    //
    //     _context.Visits.Add(entity);
    //     _context.SaveChanges();
    //     var response = new PatientController.VisitDto(
    //         entity.IdVisit,
    //         doctor.FirstName + " " + doctor.LastName,
    //         entity.Date,
    //         entity.Price.ToString(CultureInfo.InvariantCulture)
    //     );
    //     //todo: other checks
    //
    //     var location = Url.Action(nameof(PostVisit), new { id = entity.IdVisit }) ?? $"/{entity.IdVisit}";
    //     return Created(location, response);
    // }
    //
    // //todo: request validation
    // public class CreateVisitRequest
    // {
    //     public int IdPatient { get; set; }
    //     public int IdDoctor { get; set; }
    //     public DateTime Date { get; set; }
    // }
}