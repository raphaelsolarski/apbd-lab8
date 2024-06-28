using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers;

[Route("api")]
[ApiController]
public class PatientController : ControllerBase
{
    //todo: use async api
    //todo: use initial migration for inserts
    // private readonly ClinicContext _context;
    //
    // public PatientController(ClinicContext context)
    // {
    //     _context = context;
    // }
    //
    // [HttpGet("/patients/{id:int}")]
    // public IActionResult GetPatient(int id)
    // {
    //     var patient = _context.Patients
    //         .Include(p => p.Visits)
    //         .Select(p => new PatientDto()
    //         {
    //             Id = p.IdPatient,
    //             FirstName = p.FirstName,
    //             LastName = p.LastName,
    //             Birthdate = p.Birthdate,
    //             NumberOfVisit = p.Visits.Count,
    //             TotalAmountMoneySpent = p.Visits.Sum(v => v.Price).ToString(CultureInfo.InvariantCulture),
    //             Visits = p.Visits.Select(v =>
    //                 new VisitDto(
    //                     v.IdVisit,
    //                     v.IdDoctorNavigation.FirstName + " " + v.IdDoctorNavigation.LastName,
    //                     v.Date,
    //                     v.Price.ToString(CultureInfo.InvariantCulture)
    //                 )
    //             ).ToList()
    //         })
    //         .SingleOrDefault(p => p.Id == id);
    //
    //     if (patient == null)
    //     {
    //         return NotFound("Patient with given id does not exist");
    //     }
    //
    //     return Ok(patient);
    // }
    //
    // public class PatientDto
    // {
    //     public int Id { get; set; }
    //     public string FirstName { get; set; }
    //     public string LastName { get; set; }
    //     public DateOnly Birthdate { get; set; }
    //
    //     public string TotalAmountMoneySpent { get; set; }
    //
    //     public int NumberOfVisit { get; set; }
    //     public ICollection<VisitDto> Visits { get; set; }
    // }
    //
    // public class VisitDto(int idVisit, string doctor, DateTime date, string price)
    // {
    //     public int IdVisit { get; set; } = idVisit;
    //     public string Doctor { get; set; } = doctor;
    //     public DateTime Date { get; set; } = date;
    //     public string Price { get; set; } = price;
    // }
}