using AlertToCare.Models;
using AlertToCare.Repository;

namespace AlertToCare.BusinessLogic
{
    public class PatientBusinessLogic : IPatientBusinessLogic
    {
        readonly IPatientDataRepository _patientDataRepository;
        public PatientBusinessLogic(IPatientDataRepository repo)
        {
            this._patientDataRepository = repo;
        }

        public PatientDataModel InsertPatient(PatientDataModel patient)
        {
            _patientDataRepository.AddPatient(patient);
            return patient;
        }

        public PatientDataModel FetchPatientInfoFromBedId(string bedId)
        {
            var patientResult = _patientDataRepository.FetchPatientInfoFromBedId(bedId);
            return patientResult;
        }
        public void FreeTheBed(int patientId)
        {
            _patientDataRepository.RemovePatientFromBed(patientId);
        }

        public void AllotBedToPatient(BedAllotmentModel allotBed)
        {
            _patientDataRepository.AllotBedToPatient(allotBed);
        }
    }
}
