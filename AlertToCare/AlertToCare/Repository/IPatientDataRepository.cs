namespace AlertToCare.Repository
{
    public interface IPatientDataRepository
    {
        public Models.PatientDataModel InsertPatient(Models.PatientDataModel patient);
        public bool AllotBedToPatient(Models.BedAllotmentModel allotBed);
        public bool FreeTheBed(int patientId);
        public Models.PatientDataModel FetchPatientInfoFromBedId(string statusBedId);
    }
}
