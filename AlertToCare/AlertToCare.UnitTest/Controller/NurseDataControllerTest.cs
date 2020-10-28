
using AlertToCare.BusinessLogic;
using AlertToCare.Controllers;
using AlertToCare.Models;
using AlertToCare.UnitTest.MockBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace AlertToCare.UnitTest.Controller
{
    
    public class NurseDataControllerTest
    {
        
        readonly MockNurseBusinessLogic _mock = new MockNurseBusinessLogic();
        [Fact]
        
        public void TestValidateForAdmin()
        {
            var nurse = new NurseDataModel
            {

                NurseId = "333",
                NurseName = "Admin",
                WardId = "233"
            };

            NurseDataController nurseData = new NurseDataController(_mock);

            var response = nurseData.Validate(nurse);

            Assert.True(response == "Admin Login");

        }
        
        [Fact]

        public void TestForMatchIdWhenIdSame()
        {
            NurseDataController nurseData = new NurseDataController(_mock);
            string a = "a";
            string b = "a";

            var response = nurseData.MatchId(a, b);

            Assert.True(response == "Validation Succesfull");
        }

        [Fact]
        public void TestForMatchIdWhenIdDiff()
        {
            NurseDataController nurseData = new NurseDataController(_mock);
            string a = "a";
            string b = "b";

            var response = nurseData.MatchId(a, b);

            Assert.True(response == "Validation Failed");
        }

        [Fact]
        public void TestForMatchName()
        {
            NurseDataController nurseData = new NurseDataController(_mock);

            string a = "a";
            string id = "1";

            var response = nurseData.MatchName(a, id);

            Assert.True(response == "Validation Failed");

        }

        [Fact]

        public void TestForNurseAddSuccessfull()
        {
            NurseDataController nurseData= new NurseDataController(_mock);
            var nurse = new NurseDataModel
            {

                NurseId = "456",
                NurseName = "Hero",
                WardId = "213"
           };

            var actualResponse = nurseData.Post(nurse);
            var actualResponseObject = actualResponse.Result as OkObjectResult;

            Assert.NotNull(actualResponseObject);
            Assert.Equal(200, actualResponseObject.StatusCode);

        }

        [Fact]

        public void TestForGetMethod()
        {
            var controller = new NurseDataController(_mock);

            var response = controller.Get();

            var actualResponse = response as List<NurseDataModel>;

            Assert.NotNull(actualResponse);
        }

       
    }
}
