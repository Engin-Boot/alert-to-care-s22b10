using AlertToCare.Models;
using System.Collections.Generic;

namespace AlertToCare.BusinessLogic
{
    public interface INurseBusinessLogic
    {
        public NurseDataModel InsertNurse(NurseDataModel nurse);

        public IEnumerable<NurseDataModel> GetNurse();

    }
}
