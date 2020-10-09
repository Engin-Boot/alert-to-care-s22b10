using System;
using AlertToCare.Models;
using AlertToCare.Validator;
using Microsoft.AspNetCore.Mvc;
using ControllerBase = Microsoft.AspNetCore.Mvc.ControllerBase;

namespace AlertToCare.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class PatientDataController : ControllerBase
    {
        readonly Repository.IPatientDataRepository _patientDataRepository;
        public PatientDataController(Repository.IPatientDataRepository repo)
        {
            this._patientDataRepository = repo;
        }


        [HttpPost("PatientInfo")]
        public IActionResult  InsertPatient([FromBody] PatientDataModel patient)
        {
            string[] patientResponse;
            if (!PatientValidator.ValidatePatient(patient))
                return BadRequest("Please enter valid input");
            try
            {
                patientResponse = _patientDataRepository.InsertPatient(patient);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to insert patient information");
            }

            var jsonData = @"{'patientId': '" + patientResponse[0] +
                           "', 'patientName': '" + patientResponse[1] +
                           "','email': '" + patientResponse[2] +
                           "','address': '" + patientResponse[3] +
                           "','mobile': '" + patientResponse[4]
                           + "'}";
           return Ok(jsonData);
           }

        [HttpPost("AllotBedToPatient")]
        public IActionResult AllotBedToPatient([FromBody] BedAllotmentModel bedAllotment)
        {
            bool isBedAlloted = _patientDataRepository.AllotBedToPatient(bedAllotment);
            if (isBedAlloted == false)
                return StatusCode(500);
            else
                return Ok();
        }
        [HttpPost("DischargePatient/{patientId}")]
        public IActionResult DischargePatient(int patientId)
        {
            bool isBedAlloted = _patientDataRepository.FreeTheBed(patientId);
            if (isBedAlloted == false)
                return StatusCode(500);
            else
                return Ok();
        }
    }
}
