using System;
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
    }
}
