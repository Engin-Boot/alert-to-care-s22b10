using System;
using System.Collections.Generic;
using AlertToCare.BusinessLogic;
using AlertToCare.Models;

namespace AlertToCare.UnitTest.MockBusinessLogic
{
    class MockIcuLayoutBusinessLogic: IIcuLayoutBusinessLogic
    {
        public void AddLayoutInformation(IcuWardLayoutModel objLayout)
        {
            if(objLayout.Department == "radonc")
                throw new Exception("");
        }

        public IEnumerable<IcuWardInformation> getall()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BedInformation> getBedInformation(string WardNumber)
        {
            throw new NotImplementedException();
        }
    }
}
