using AlertToCare.Models;
using System;

namespace AlertToCare.BusinessLogic
{
    public interface IPatientBusinessLogic
    {
        public PatientDataModel InsertPatient(PatientDataModel patient);
        public Tuple<PatientDataModel, BedInformation> AllotBedToPatient(BedAllotmentModel allotBed);
        public void FreeTheBed(int patientId);
        public PatientDataModel FetchPatientInfoFromBedId(string bedId);
        public PatientDataModel FetchPatientInfo(int patientId);
        public void allotBed(PatientDataModel patient, string wardId, string bedId);
    }
}
