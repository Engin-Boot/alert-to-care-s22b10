using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Repository
{
    public interface IPatientDataRepository
    {
        public string[] InsertPatient(Models.PatientDataModel patient);
    }
}
