using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlertToCare.BusinessLogic;
using AlertToCare.Models;

namespace AlertToCare.UnitTest.MockBusinessLogic
{
    class MockNurseBusinessLogic : INurseBusinessLogic
    {
        public IEnumerable<NurseDataModel> GetNurse()
        {
            IEnumerable<NurseDataModel> list = new List<NurseDataModel>();

            var data = new NurseDataModel();

            list.Append(data);

            return list;
        }

       

        public NurseDataModel InsertNurse(NurseDataModel nurse)
        {
            nurse.NurseId = "44";

            return nurse;
        }
    }
}
