﻿using AlertToCare.Controllers;
using AlertToCare.Models;
using AlertToCare.UnitTest.MockBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Xunit;

namespace AlertToCare.UnitTest.Controller
{
    public class IcuLayoutControllerTest
    {
        private readonly MockIcuLayoutBusinessLogic _repo = new MockIcuLayoutBusinessLogic();
        [Fact]
        public void TestInsertIcuWardInfoSuccessfully()
        {
            var controller = new IcuLayoutController(_repo);
            IcuWardLayoutModel model = new IcuWardLayoutModel
            {
                Department = "MR",
                NumberOfBed = 2,
                NumberOfColumn = 2,
                NumberOfRow = 1,
                WardNumber = "1A1"
            };
            var actualResponse = controller.InsertIcuWardInfo(model);
            var actualResponseObject = actualResponse as OkObjectResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(200, actualResponseObject.StatusCode);
        }
        [Fact]
        public void TestInsertIcuWardInfoUnSuccessful()
        {
            var controller = new IcuLayoutController(_repo);
            IcuWardLayoutModel model = new IcuWardLayoutModel
            {
                Department = "radonc",
                NumberOfBed = 2,
                NumberOfColumn = 2,
                NumberOfRow = 1,
                WardNumber = "1A1"
            };
            var actualResponse = controller.InsertIcuWardInfo(model);
            var actualResponseObject = actualResponse as StatusCodeResult;
            Assert.NotNull(actualResponseObject);
            Assert.Equal(500, actualResponseObject.StatusCode);
        }
        [Fact]
        public void TestgetMethod()
        {
            var controller = new IcuLayoutController(_repo);
            var response = controller.Get();
            var actualresponse = response as List<IcuWardInformation>;
            Assert.NotNull(actualresponse);
        }
        [Fact]
        public void TestgetIcuWardInfo()
        {
            var controller = new IcuLayoutController(_repo);
            var response = controller.GetIcuWardInfo("1A1");
            var actualresponse = response as List<BedInformation>;
            Assert.NotNull(actualresponse);
        }
    }
}
