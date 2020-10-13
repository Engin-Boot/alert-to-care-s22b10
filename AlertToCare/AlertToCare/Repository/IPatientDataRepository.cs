using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare.Models;

namespace AlertToCare.Repository
{
    public interface IPatientDataRepository
    {
        public void AddPatient(PatientDataModel patient);
        public PatientDataModel FetchPatientInfoFromBedId(string bedId);
        public void RemovePatientFromBed(int patientId);
        public void AllotBedToPatient(BedAllotmentModel allotBed);
    }
}
