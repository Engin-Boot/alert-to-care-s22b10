using System;
using System.Collections.Generic;
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
        public ActionResult<IEnumerable<dynamic>> InsertPatient([FromBody] PatientDataModel patient)
        {
            PatientDataModel patientInfo;
            if (!PatientValidator.ValidatePatient(patient))
                return BadRequest("Please enter valid input");
            try
            {
                patientInfo = _patientDataRepository.InsertPatient(patient);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to insert patient information");
            }

            var responseData = new Dictionary<string, dynamic>
            {
                {"patientId", patientInfo.PatientId},
                {"patientName", patientInfo.PatientName},
                {"email", patientInfo.Email},
                {"address", patientInfo.Address},
                {"mobile", patientInfo.Mobile},
            };
            return Ok(responseData);
           }

        [HttpPost("AllotBedToPatient")]
        public IActionResult AllotBedToPatient([FromBody] BedAllotmentModel bedAllotment)
        {
            AllotedBedValidator bedValidator = new AllotedBedValidator();
            bool isDataValid = bedValidator.ValidateBedAlloted(bedAllotment);
            if (!isDataValid)
                return BadRequest("Please Enter Valid Input");
            bool isBedAlloted = _patientDataRepository.AllotBedToPatient(bedAllotment);
            if (isBedAlloted == false)
                return StatusCode(500);
            return Ok();
        }
        [HttpPost("DischargePatient/{patientId}")]
        public IActionResult DischargePatient(int patientId)
        {
            bool isBedAlloted = _patientDataRepository.FreeTheBed(patientId);
            if (isBedAlloted == false)
                return StatusCode(500);
            return Ok();
        }
    }
}
