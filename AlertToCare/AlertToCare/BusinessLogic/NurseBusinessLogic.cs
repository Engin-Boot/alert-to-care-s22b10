using AlertToCare.Models;
using AlertToCare.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.BusinessLogic
{
    public class NurseBusinessLogic : INurseBusinessLogic
    {
        readonly INurseDataRepository nurseDataRepository;

        public NurseBusinessLogic(INurseDataRepository repo)
        {
            this.nurseDataRepository = repo;
        }
        public IEnumerable<NurseDataModel> getNurse()
        {
            return nurseDataRepository.GetAll();
        }

        public NurseDataModel InsertNurse(NurseDataModel nurse)
        {
            nurseDataRepository.AddNurse(nurse);
            return nurse;
        }
    }
}
