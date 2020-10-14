using System;
using System.Collections.Generic;
using AlertToCare.BusinessLogic;
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
        readonly IPatientBusinessLogic _patientBusinessLogic;
        public PatientDataController(IPatientBusinessLogic operation)
        {
            this._patientBusinessLogic = operation;
        }


        [HttpPost("PatientInfo")]
        public ActionResult<IEnumerable<dynamic>> InsertPatient([FromBody] PatientDataModel patient)
        {
            PatientDataModel patientInfo;
            if (!PatientValidator.ValidatePatient(patient))
                return BadRequest("Please enter valid input");
            try
            {
                patientInfo = _patientBusinessLogic.InsertPatient(patient);
            }
            catch
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
            try
            {
                _patientBusinessLogic.AllotBedToPatient(bedAllotment);
            }
            catch(Exception e)
            {
                return StatusCode(500);
            }
            return Ok();
        }
        [HttpPost("DischargePatient/{patientId}")]
        public IActionResult DischargePatient(int patientId)
        {
            try
            {
                _patientBusinessLogic.FreeTheBed(patientId);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
