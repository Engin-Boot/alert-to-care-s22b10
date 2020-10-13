﻿using System.Collections.Generic;
using AlertToCare.Controllers;
using AlertToCare.Models;
using AlertToCare.UnitTest.MockBusinessLogic;
using AlertToCare.UnitTest.MockRepository;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AlertToCare.UnitTest.Controller
{
    public class MedicalDeviceDataControllerTest
    {
        readonly MockPatientBusinessLogic patientRepo = new MockPatientBusinessLogic();
        readonly MockDeviceBusinessLogic deviceRepo = new MockDeviceBusinessLogic();

        [Fact]
        public void TestInsertDeviceSuccessfully()
        {
            var controller = new MedicalDeviceController(deviceRepo, patientRepo);
            MedicalDevice device = new MedicalDevice {DeviceName = "device", MaxValue = 100, MinValue = 50};
            var actualResponse = controller.InsertDevice(device);
            var actualResponseObject = actualResponse as OkObjectResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(200, actualResponseObject.StatusCode);
        }
        [Fact]
        public void TestInsertDeviceValidationFailure()
        {
            var controller = new MedicalDeviceController(deviceRepo, patientRepo);
            MedicalDevice device = new MedicalDevice {DeviceName = "device", MaxValue = 20, MinValue = 50};
            var actualResponse = controller.InsertDevice(device);
            var actualResponseObject = actualResponse as BadRequestObjectResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(400, actualResponseObject.StatusCode);
        }
        [Fact]
        public void TestInsertDeviceUnsuccessful()
        {
            var controller = new MedicalDeviceController(deviceRepo, patientRepo);
            MedicalDevice device = new MedicalDevice {DeviceName = "Oxymeter", MaxValue = 100, MinValue = 50};
            var actualResponse = controller.InsertDevice(device);
            var actualResponseObject = actualResponse as ObjectResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(500, actualResponseObject.StatusCode);
        }
        [Theory]
        [InlineData("device")]
        [InlineData("")]
        public void TestAlertDeviceSuccessfully(string deviceName)
        {
            var controller = new MedicalDeviceController(deviceRepo, patientRepo);
            var model = new MedicalStatusDataModel {BedId = "1A1"};
            var medicalDevice = new Dictionary<string, int>();
            if(deviceName!="")
                medicalDevice.Add(deviceName, 50);
            model.MedicalDevice = medicalDevice;
            var actualResponse = controller.IsAlert(model);
            var actualResponseObject = actualResponse.Result as OkObjectResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(200, actualResponseObject.StatusCode);
        }

        [Theory]
        [InlineData("1B1")]
        public void TestAlertDeviceInvalidDevice(string bedId)
        {
            var controller = new MedicalDeviceController(deviceRepo, patientRepo);
            var model = new MedicalStatusDataModel {BedId = bedId };
            var medicalDevice = new Dictionary<string, int> {{"deviceName", 50}};
            model.MedicalDevice = medicalDevice;
            var actualResponse = controller.IsAlert(model);
            var actualResponseObject = actualResponse.Result as BadRequestObjectResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(400, actualResponseObject.StatusCode);
        }
   }
}
