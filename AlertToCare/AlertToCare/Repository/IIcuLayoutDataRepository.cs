using System.Collections.Generic;
using AlertToCare.Models;
using System.Collections.Generic;

namespace AlertToCare.Repository
{
    public interface IIcuLayoutDataRepository
    {
        public void InsertBed(BedInformation bed);
        public void InsertLayout(IcuWardInformation layout);

        public IEnumerable<IcuWardInformation> Get();
        public IEnumerable<BedInformation> getAllBedsInWard(string wardNumber);
    }
}
