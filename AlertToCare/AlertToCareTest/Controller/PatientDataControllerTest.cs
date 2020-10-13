using AlertToCare.Controllers;
using AlertToCare.Models;
using AlertToCare.Repository;
using AlertToCare.UnitTest.MockRepository;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AlertToCare.UnitTest.Controller
{
    public class PatientDataControllerTest
    {
        MockPatientBusinessLogic operations = new MockPatientBusinessLogic();

        [Fact]
        public void TestInsertPatientSuccessfully()
        {
            PatientDataController controller = new PatientDataController(operations);
            var patient = new PatientDataModel();
            patient.PatientName = "p1";
            patient.Address = "address";
            patient.Mobile = "9898989898";
            patient.Email = "p1@email.com";
            var actualResponse = controller.InsertPatient(patient);
            var actualResponseObject = actualResponse.Result as OkObjectResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(200, actualResponseObject.StatusCode);
        }
        [Fact]
        public void TestInsertPatientValidationFalure()
        {
            PatientDataController controller = new PatientDataController(operations);
            var patient = new PatientDataModel();
            patient.PatientName = "p1";
            patient.Address = "address";
            patient.Mobile = "98989898";
            patient.Email = "p1@email.com";
            var actualResponse = controller.InsertPatient(patient);
            var actualResponseObject = actualResponse.Result as BadRequestObjectResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(400, actualResponseObject.StatusCode);
        }

        [Fact]
        public void TestInsertPatientThrowsException()
        {
            PatientDataController controller = new PatientDataController(operations);
            var patient = new PatientDataModel();
            patient.PatientName = "Hari";
            patient.Address = "address";
            patient.Mobile = "9898933898";
            patient.Email = "p1@email.com";
            var actualResponse = controller.InsertPatient(patient);
            var actualResponseObject = actualResponse.Result as ObjectResult;
            Assert.NotNull(actualResponse);
            Assert.Equal(500, actualResponseObject.StatusCode);
        }

        [Fact]
        public void TestAllotPatientSuccessfully()
        {
            PatientDataController controller = new PatientDataController(operations);
            BedAllotmentModel bedAllotment =new BedAllotmentModel();
            bedAllotment.PatientId = 1;
            bedAllotment.Department = "Cancer";
            var actualResponse = controller.AllotBedToPatient(bedAllotment);
            var actualResponseObject = actualResponse as OkResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(200, actualResponseObject.StatusCode);
        }
        [Fact]
        public void TestAllotPatientUnSuccessful()
        {
            PatientDataController controller = new PatientDataController(operations);
            BedAllotmentModel bedAllotment = new BedAllotmentModel();
            bedAllotment.PatientId = 2;
            bedAllotment.Department = "Cancer";
            var actualResponse = controller.AllotBedToPatient(bedAllotment);
            var actualResponseObject = actualResponse as StatusCodeResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(500, actualResponseObject.StatusCode);
        }
        [Fact]
        public void TestDischargePatientSuccessfully()
        {
            PatientDataController controller = new PatientDataController(operations);
            var actualResponse =  controller.DischargePatient(1);
            var okResult = actualResponse as OkResult;
            // Assert
            
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }
        [Fact]
        public void TestDischargePatientUnSuccessful()
        {
            PatientDataController controller = new PatientDataController(operations);
            var actualResponse = controller.DischargePatient(2);
            var respone = actualResponse as StatusCodeResult;
            // Assert

            Assert.NotNull(respone);
            Assert.Equal(500, respone.StatusCode);
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
