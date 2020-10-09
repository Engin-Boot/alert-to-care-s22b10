namespace AlertToCare.Repository
{
    public interface IPatientDataRepository
    {
        public string[] InsertPatient(Models.PatientDataModel patient);
        public bool AllotBedToPatient(Models.BedAllotmentModel allotBed);
        public bool FreeTheBed(int patientId);
    }
}
