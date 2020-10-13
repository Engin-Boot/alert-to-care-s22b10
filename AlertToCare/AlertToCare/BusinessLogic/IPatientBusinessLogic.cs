namespace AlertToCare.BusinessLogic
{
    public interface IPatientBusinessLogic
    {
        public Models.PatientDataModel InsertPatient(Models.PatientDataModel patient);
        public void AllotBedToPatient(Models.BedAllotmentModel allotBed);
        public void FreeTheBed(int patientId);
        public Models.PatientDataModel FetchPatientInfoFromBedId(string statusBedId);
    }
}
