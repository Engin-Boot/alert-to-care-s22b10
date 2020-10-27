using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<BedInformation> getIcuWardInfo(string wardid)
        {
            IEnumerable<BedInformation> list = new List<BedInformation>();
            var data = new BedInformation();
            list.Append(data);

            return list;

        }
        public IEnumerable<IcuWardInformation> getall()
        {
            IEnumerable<IcuWardInformation> list = new List<IcuWardInformation>();
            var data = new IcuWardInformation();
            list.Append(data);

            return list;
        }

        public IEnumerable<BedInformation> getBedInformation(string WardNumber)
        {
            return new List<BedInformation>();
        }
    }
}
