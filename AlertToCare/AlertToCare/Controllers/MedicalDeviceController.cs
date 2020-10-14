using System;
using System.Collections.Generic;
using System.Linq;
using AlertToCare.BusinessLogic;
using AlertToCare.Models;
using AlertToCare.Validator;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCare.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class MedicalDeviceController : ControllerBase
    {
        readonly IMedicalDeviceBusinessLogic _deviceDataRepository;
        readonly IPatientBusinessLogic _patientDataRepository;
        public MedicalDeviceController(IMedicalDeviceBusinessLogic deviceRepo,
            IPatientBusinessLogic patientRepo)
        {
            this._deviceDataRepository = deviceRepo;
            this._patientDataRepository = patientRepo;
        }


        [HttpPost("MedicalDevice")]
        public IActionResult InsertDevice([FromBody] MedicalDevice device)
        {
            if (!DeviceValidator.ValidateDevice(device))
                return BadRequest("Please enter valid input");
            try
            {
                _deviceDataRepository.InsertDevice(device);
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to insert device information");
            }

            return Ok("Insertion successful");
        }

        [HttpPost("Alert")]
        public ActionResult<IEnumerable<dynamic>> IsAlert([FromBody] MedicalStatusDataModel status)
        {
            PatientDataModel patientInfo;
            IEnumerable<string> alertingDevice;
            try
            {
                patientInfo = _patientDataRepository.FetchPatientInfoFromBedId(status.BedId);
                checkPatientValid(patientInfo);

                alertingDevice = _deviceDataRepository.Alert(status);
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid Request Body");
            }

            var responseData = new Dictionary<string, dynamic>
            {
                {"patientId", patientInfo.PatientId},
                {"email", patientInfo.Email},
                {"address", patientInfo.Address},
                {"mobile", patientInfo.Mobile},
                {"Bed Id", status.BedId},
                {"Alert Device", alertingDevice}
            };
            return !alertingDevice.Any() ? Ok("Patient Condition OK") : Ok(responseData);
        }

        private void checkPatientValid(PatientDataModel patientInfo)
        {
            if(patientInfo == null)
                throw  new ArgumentException("Invalid bed id");
        }
    }
}
