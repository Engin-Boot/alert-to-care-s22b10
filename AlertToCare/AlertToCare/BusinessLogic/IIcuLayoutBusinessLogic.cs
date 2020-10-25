using System.Collections.Generic;
using AlertToCare.Models;

namespace AlertToCare.BusinessLogic
{
    public interface IIcuLayoutBusinessLogic
    {
        public void AddLayoutInformation(IcuWardLayoutModel objLayout);
        public IEnumerable<BedInformation> getBedInformation(string WardNumber);
    }
}
