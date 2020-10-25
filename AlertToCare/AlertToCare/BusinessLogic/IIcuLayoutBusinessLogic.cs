
﻿using AlertToCare.Models;
using System.Collections;
using System.Collections.Generic;


namespace AlertToCare.BusinessLogic
{
    public interface IIcuLayoutBusinessLogic
    {
        public void AddLayoutInformation(IcuWardLayoutModel objLayout);

        public IEnumerable<IcuWardInformation> getall();

        public IEnumerable<BedInformation> getBedInformation(string WardNumber);

    }


}
