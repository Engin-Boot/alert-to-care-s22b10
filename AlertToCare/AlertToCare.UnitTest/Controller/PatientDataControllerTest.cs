using AlertToCare.Controllers;
using AlertToCare.Models;
using AlertToCare.UnitTest.MockBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AlertToCare.UnitTest.Controller
{
    public class PatientDataControllerTest
    {
        readonly MockPatientBusinessLogic _operations = new MockPatientBusinessLogic();

        [Fact]
        public void TestInsertPatientSuccessfully()
        {
            PatientDataController controller = new PatientDataController(_operations);
            var patient = new PatientDataModel
            {
                PatientName = "p1", Address = "address", Mobile = "9898989898", Email = "p1@email.com"
            };
            var actualResponse = controller.InsertPatient(patient);
            var actualResponseObject = actualResponse.Result as OkObjectResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(200, actualResponseObject.StatusCode);
        }
        [Fact]
        public void TestInsertPatientValidationFalure()
        {
            PatientDataController controller = new PatientDataController(_operations);
            var patient = new PatientDataModel
            {
                PatientName = "p1", Address = "address", Mobile = "98989898", Email = "p1@email.com"
            };
            var actualResponse = controller.InsertPatient(patient);
            var actualResponseObject = actualResponse.Result as BadRequestObjectResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(400, actualResponseObject.StatusCode);
        }

        [Fact]
        public void TestInsertPatientThrowsException()
        {
            PatientDataController controller = new PatientDataController(_operations);
            var patient = new PatientDataModel
            {
                PatientName = "Hari", Address = "address", Mobile = "9898933898", Email = "p1@email.com"
            };
            var actualResponse = controller.InsertPatient(patient);
            var actualResponseObject = actualResponse.Result as ObjectResult;
            Assert.NotNull(actualResponse);
            Assert.Equal(500, actualResponseObject.StatusCode);
        }

        [Fact]
        public void TestAllotPatientSuccessfully()
        {
            PatientDataController controller = new PatientDataController(_operations);
            BedAllotmentModel bedAllotment = new BedAllotmentModel {PatientId = 1, Department = "Cancer"};
            var actualResponse = controller.AllotBedToPatient(bedAllotment);
            var actualResponseObject = actualResponse as OkObjectResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(200, actualResponseObject.StatusCode);
        }
        [Fact]
        public void TestAllotPatientUnSuccessful()
        {
            PatientDataController controller = new PatientDataController(_operations);
            BedAllotmentModel bedAllotment = new BedAllotmentModel {PatientId = 2, Department = "Cancer"};
            var actualResponse = controller.AllotBedToPatient(bedAllotment);
            var actualResponseObject = actualResponse as StatusCodeResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(500, actualResponseObject.StatusCode);
        }
        [Fact]
        public void TestDischargePatientSuccessfully()
        {
            PatientDataController controller = new PatientDataController(_operations);
            var actualResponse =  controller.DischargePatient(1);
            var okResult = actualResponse as OkResult;
            // Assert
            
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public void TestDischargePatientUnSuccessful()
        {
            PatientDataController controller = new PatientDataController(_operations);
            var response = controller.DischargePatient(2) as StatusCodeResult;
            
            // Assert

            Assert.NotNull(response);
            Assert.Equal(500, response.StatusCode);
        }
        /*[Fact]
        public void TestAllotBedToPatientSuccessful()
        {
            var patientData = new PatientDataRepository(_context);
            BedAllotmentModel bedAllotment = new BedAllotmentModel();
            bedAllotment.PatientId = 12;
            bedAllotment.Department = "MR";
            patientData.AllotBedToPatient(bedAllotment);
        }*/
    }
}
