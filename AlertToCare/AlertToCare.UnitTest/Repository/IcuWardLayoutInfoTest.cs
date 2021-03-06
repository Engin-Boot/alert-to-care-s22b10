﻿
using System.Collections.Generic;
using System.Linq;
using AlertToCare.Models;
using AlertToCare.Repository;
using Xunit;

namespace AlertToCare.UnitTest.Repository
{
    public class IcuWardLayoutInfoTest: InMemoryContext
    {
        [Fact]
        public void TestInsertBedInformation()
        {
            var layoutData = new IcuLayoutDataRepository(Context);
            var bed = new BedInformation
            {
                PatientId = 10,
                BedId = "1d3",
                WardNumber = "1d",
                BedInColumn = 2,
                BedInRow = 2
            };
            layoutData.InsertBed(bed);
            var wardInDb = Context.BedInformation.First
                (p => p.WardNumber == "1d");
            Assert.NotNull(wardInDb);
        }
        [Fact]
        public void TestInsertWardLayoutInformation()
        {
            var layoutData = new IcuLayoutDataRepository(Context);
            var layout = new IcuWardInformation
            {
                WardNumber = "1Z1",
                Department = "MR",
                TotalBed = 3
            };
            layoutData.InsertLayout(layout);
            var wardInDb = Context.IcuWardInformation.First
                (p => p.WardNumber == "1Z1");
            Assert.NotNull(wardInDb);
        }
        [Fact]
        public void TestGet()
        {
            var layoutData = new IcuLayoutDataRepository(Context);
            var response = layoutData.Get();
            var actualresponse = response as List<IcuWardInformation>;
            Assert.NotNull(actualresponse);
        }
        [Fact]
        public void TestgetAllBedsInWard()
        {
            var layoutData = new IcuLayoutDataRepository(Context);
            var response = layoutData.GetAllBedsInWard("1A1");
            var actualresponse = response as List<BedInformation>;
            Assert.NotNull(actualresponse);
        }
    }
}
