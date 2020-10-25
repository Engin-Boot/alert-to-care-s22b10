using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.BusinessLogic
{
    public interface INurseBusinessLogic
    {
        public NurseDataModel InsertNurse(NurseDataModel nurse);

        public IEnumerable<NurseDataModel> getNurse();

    }
}
