namespace AlertToCare.Repository
{
    public interface IPatientDataRepository
    {
        public string[] InsertPatient(Models.PatientDataModel patient);
    }
}
