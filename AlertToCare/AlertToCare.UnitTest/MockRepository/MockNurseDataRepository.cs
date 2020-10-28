using AlertToCare.Models;
using AlertToCare.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlertToCare.UnitTest.MockRepository
{
    class MockNurseDataRepository : INurseDataRepository
    {
        public void AddNurse(NurseDataModel nurse)
        {
            
        }

        public IEnumerable<NurseDataModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
