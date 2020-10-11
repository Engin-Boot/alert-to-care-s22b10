using System;
using System.Collections.Generic;
using System.Linq;
using AlertToCare.Models;
using AlertToCare.Validator;
using Microsoft.AspNetCore.Mvc;

namespace AlertToCare.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class MedicalDeviceController : ControllerBase
    {
        readonly Repository.IMedicalDeviceDataRepository _deviceDataRepository;
        readonly Repository.IPatientDataRepository _patientDataRepository;
        public MedicalDeviceController(Repository.IMedicalDeviceDataRepository deviceRepo,
            Repository.IPatientDataRepository patientRepo)
        {
            this._deviceDataRepository = deviceRepo;
            this._patientDataRepository = patientRepo;
        }


        [HttpPost("MedicalDevice")]
        public IActionResult InsertDevice([FromBody] DeviceDataModel device)
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
                if (patientInfo == null)
                    return BadRequest("Invalid Bed Id");
                alertingDevice = _deviceDataRepository.Alert(status);
            }
            catch (ArgumentException)
            {
                return BadRequest("Invalid Medical Device");
            }
            catch (Exception)
            {
                return StatusCode(500, "unable to check alert");
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
    }
}
