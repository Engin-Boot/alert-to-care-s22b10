using AlertToCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Repository
{
    public interface INurseDataRepository
    {
        public void AddNurse(NurseDataModel nurse);

        public IEnumerable<NurseDataModel> GetAll();
        

    }
}
