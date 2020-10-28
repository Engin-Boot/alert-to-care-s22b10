using System.Collections.Generic;
using AlertToCare.Models;
using AlertToCare.Repository;

namespace AlertToCare.UnitTest.MockRepository
{
    class MockIcuLayoutDataRepository: IIcuLayoutDataRepository
    {
        public IEnumerable<IcuWardInformation> Get()
        {
            IEnumerable<IcuWardInformation> test = new List<IcuWardInformation>();
            return test;
        }

        public IEnumerable<BedInformation> getAllBedsInWard(string wardNumber)
        {
            IEnumerable<BedInformation> test = new List<BedInformation>();
            return test;
        }

        public void InsertBed(BedInformation bed)
        {
            
        }

        public void InsertLayout(IcuWardInformation layout)
        {
            
        }
    }
}
