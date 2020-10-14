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
<<<<<<< HEAD
            catch (Exception)
=======
            catch
>>>>>>> 8c6598d8c6d0b2e6d5350b08d82c35e7d43980dd
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
<<<<<<< HEAD
            AllotedBedValidator bedValidator = new AllotedBedValidator();
            bool isDataValid = bedValidator.ValidateBedAlloted(bedAllotment);
            if (!isDataValid)
                return BadRequest("Please Enter Valid Input");
            bool isBedAlloted = _patientDataRepository.AllotBedToPatient(bedAllotment);
            if (isBedAlloted == false)
=======
            try
            {
                _patientBusinessLogic.AllotBedToPatient(bedAllotment);
            }
            catch
            {
>>>>>>> 8c6598d8c6d0b2e6d5350b08d82c35e7d43980dd
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
