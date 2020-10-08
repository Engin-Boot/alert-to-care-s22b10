using System;
using AlertToCare.Models;
using AlertToCare.Validator;
using Microsoft.AspNetCore.Mvc;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace AlertToCare.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    [ApiController]

    public class PatientDataController : ControllerBase
    {
        Repository.IPatientDataRepository _patientDataRepository;
        public PatientDataController(Repository.IPatientDataRepository repo)
        {
            this._patientDataRepository = repo;
        }


        [Microsoft.AspNetCore.Mvc.HttpPost("PatientInfo")]
        public IActionResult  InsertPatient([System.Web.Http.FromBody] PatientDataModel patient)
        {
            string[] patientResponse = null;
            if (!PatientValidator.ValidatePatient(patient))
                return BadRequest();
            try
            {
                patientResponse = _patientDataRepository.InsertPatient(patient);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            if (patientResponse == null)
            {
                return StatusCode(500);
            }
            var jsonData = @"{'patientId': '" + patientResponse[0] +
                           "', 'patientName': '" + patientResponse[1] +
                           "','email': '" + patientResponse[2] +
                           "','address': '" + patientResponse[3] +
                           "','mobile': '" + patientResponse[4]
                           + "'}";
           return Ok(jsonData);
           }
    }
}
