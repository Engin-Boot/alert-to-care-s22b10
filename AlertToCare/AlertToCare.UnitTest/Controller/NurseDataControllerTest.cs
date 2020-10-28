
using AlertToCare.BusinessLogic;
using AlertToCare.Controllers;
using AlertToCare.Models;
using AlertToCare.UnitTest.MockBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Xunit;

namespace AlertToCare.UnitTest.Controller
{
    
    public class NurseDataControllerTest
    {
        readonly INurseBusinessLogic nurseBusinessLogic;
        readonly MockNurseBusinessLogic mock = new MockNurseBusinessLogic();
        [Fact]
        
        public void TestValidateForAdmin()
        {
            var nurse = new NurseDataModel
            {

                NurseId = "333",
                NurseName = "Admin",
                wardId = "233"
            };

            NurseDataController nurseData = new NurseDataController(nurseBusinessLogic);

            var response = nurseData.validate(nurse);

            Assert.True(response == "Admin Login");

        }
        
        [Fact]

        public void TestForMatchIdWhenIdSame()
        {
            NurseDataController nurseData = new NurseDataController(nurseBusinessLogic);
            string a = "a";
            string b = "a";

            var response = nurseData.matchId(a, b);

            Assert.True(response == "Validation Succesfull");
        }

        [Fact]
        public void TestForMatchIdWhenIdDiff()
        {
            NurseDataController nurseData = new NurseDataController(nurseBusinessLogic);
            string a = "a";
            string b = "b";

            var response = nurseData.matchId(a, b);

            Assert.True(response == "Validation Failed");
        }

        [Fact]
        public void TestForMatchName()
        {
            NurseDataController nurseData = new NurseDataController(mock);

            string a = "a";
            string id = "1";

            var response = nurseData.matchName(a, id);

            Assert.True(response == "Validation Failed");

        }

        [Fact]

        public void TestForNurseAdd()
        {
            var nurseData= new NurseDataController(mock);
            var nurse = new NurseDataModel
            {

                NurseId = "456",
                NurseName = "Hero",
                wardId = "213"
           };

            var actualResponse = nurseData.Post(nurse);
            var actualResponseObject = actualResponse.Result as OkObjectResult;

            Assert.NotNull(actualResponse);

        }
        [Fact]

        public void TestForGetMethod()
        {
            var controller = new NurseDataController(mock);

            var response = controller.Get();

            var actualResponse = response as List<NurseDataModel>;

            Assert.NotNull(actualResponse);
        }
    }
}
