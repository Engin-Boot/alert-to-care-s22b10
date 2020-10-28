using AlertToCare.Models;
using AlertToCare.UnitTest.MockRepository;
using AlertToCare.BusinessLogic;
using Xunit;

namespace AlertToCare.UnitTest.BusinessLogic
{

   
    public class NurseBusinessLogicTest
    {
        readonly MockNurseDataRepository _repo = new MockNurseDataRepository();

        [Fact]

        public void TestInsertNurseSuccesful()
        {
            var nurse = new NurseDataModel();
            var nurseLogic = new NurseBusinessLogic(_repo);
            nurseLogic.InsertNurse(nurse);
        }

    }
}
