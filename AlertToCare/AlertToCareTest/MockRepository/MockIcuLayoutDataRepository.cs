using System;
using System.Collections.Generic;
using System.Text;
using AlertToCare.Models;
using AlertToCare.Repository;

namespace AlertToCare.UnitTest.MockRepository
{
    class MockIcuLayoutDataRepository: IIcuLayoutManagement
    {
        public bool GetLayoutInformation(IcuWardLayoutModel objLayout)
        {
            if (objLayout.Department == "cancer")
                return true;
            return false;
        }
    }
}
