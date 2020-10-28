using AlertToCare.Models;
using System.Collections.Generic;


namespace AlertToCare.Repository
{
    public interface INurseDataRepository
    {
        public void AddNurse(NurseDataModel nurse);

        public IEnumerable<NurseDataModel> GetAll();
        

    }
}
