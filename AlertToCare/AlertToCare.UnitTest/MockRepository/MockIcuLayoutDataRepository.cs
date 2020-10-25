using System.Collections.Generic;
using AlertToCare.Models;
using AlertToCare.Repository;

namespace AlertToCare.UnitTest.MockRepository
{
    class MockIcuLayoutDataRepository: IIcuLayoutDataRepository
    {
        public IEnumerable<IcuWardInformation> Get()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<BedInformation> getAllBedsInWard(string wardNumber)
        {
            throw new System.NotImplementedException();
        }

        public void InsertBed(BedInformation bed)
        {
            
        }

        public void InsertLayout(IcuWardInformation layout)
        {
            
        }
    }
}
