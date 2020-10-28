using AlertToCare.Models;
using AlertToCare.Repository;
using System.Collections.Generic;

namespace AlertToCare.BusinessLogic
{
    public class NurseBusinessLogic : INurseBusinessLogic
    {
        readonly INurseDataRepository _nurseDataRepository;

        public NurseBusinessLogic(INurseDataRepository repo)
        {
            this._nurseDataRepository = repo;
        }
        public IEnumerable<NurseDataModel> GetNurse()
        {
            return _nurseDataRepository.GetAll();
        }

        public NurseDataModel InsertNurse(NurseDataModel nurse)
        {
            _nurseDataRepository.AddNurse(nurse);
            return nurse;
        }
    }
}
