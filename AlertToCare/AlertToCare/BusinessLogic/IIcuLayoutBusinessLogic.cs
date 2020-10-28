using AlertToCare.Models;
using System.Collections.Generic;


namespace AlertToCare.BusinessLogic
{
    public interface IIcuLayoutBusinessLogic
    {
        public void AddLayoutInformation(IcuWardLayoutModel objLayout);

        public IEnumerable<IcuWardInformation> Getall();

        public IEnumerable<BedInformation> GetBedInformation(string wardNumber);

    }


}
