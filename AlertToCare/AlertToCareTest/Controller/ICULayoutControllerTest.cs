using AlertToCare.Controllers;
using AlertToCare.Models;
using AlertToCare.UnitTest.MockRepository;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AlertToCare.UnitTest.Controller
{
    public class IcuLayoutControllerTest
    {
        MockIcuLayoutBusinessLogic repo = new MockIcuLayoutBusinessLogic();
        [Fact]
        public void TestInsertIcuWardInfoSuccessfully()
        {
            var controller = new IcuLayoutController(repo);
            IcuWardLayoutModel model = new IcuWardLayoutModel();
            model.Department = "MR";
            model.NumberOfBed = 2;
            model.NumberOfColumn = 2;
            model.NumberOfRow = 1;
            model.WardNumber = "1A1";
            var actualResponse = controller.InsertIcuWardInfo(model);
            var actualResponseObject = actualResponse as OkObjectResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(200, actualResponseObject.StatusCode);
        }
        [Fact]
        public void TestInsertIcuWardInfoUnSuccessful()
        {
            var controller = new IcuLayoutController(repo);
            IcuWardLayoutModel model = new IcuWardLayoutModel();
            model.Department = "radonc";
            model.NumberOfBed = 2;
            model.NumberOfColumn = 2;
            model.NumberOfRow = 1;
            model.WardNumber = "1A1";
            var actualResponse = controller.InsertIcuWardInfo(model);
            var actualResponseObject = actualResponse as StatusCodeResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(500, actualResponseObject.StatusCode);
        }
    }
}
