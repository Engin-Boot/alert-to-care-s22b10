using AlertToCare.Models;
using AlertToCare.Repository;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AlertToCare.UnitTest.Repository
{
    public class NurseDataRepositoryTest:InMemoryContext
    {
        [Fact]

        public void TestInsertNurseSuccessful()
        {
            var dummyNurse = new NurseDataModel
            {
                NurseId = "123",
                NurseName = "Nurse1",
                WardId = "123"
            };

            var nurseData = new NurseDataRepository(Context);

            nurseData.AddNurse(dummyNurse);

            var nurseDataInDb = Context.NurseInfo.First
                (p => p.NurseName == "Nurse1");

            Assert.NotNull(nurseDataInDb);
         
        }

        [Fact]

        public void TestGetAllFromNurse()
        {
            var nurseData = new NurseDataRepository(Context);

            List<NurseDataModel> nurseList = (List<NurseDataModel>)nurseData.GetAll();

            Assert.NotEmpty(nurseList);

        }
    }
}
