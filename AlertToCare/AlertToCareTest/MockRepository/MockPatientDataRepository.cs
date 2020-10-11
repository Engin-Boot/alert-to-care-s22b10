using System;
using AlertToCare.Models;
using AlertToCare.Repository;

namespace AlertToCare.UnitTest.MockRepository
{
    class MockPatientDataRepository: IPatientDataRepository
    {
        public PatientDataModel InsertPatient(PatientDataModel patient)
        {
            patient.PatientId = 1;
            if (patient.PatientName == "Hari")
            {
                throw new Exception("unable to insert patient information");
            }
            return patient;
        }

        public bool AllotBedToPatient(BedAllotmentModel allotBed)
        {
            if(allotBed.PatientId ==1)
                return true;
            return false;
        }

        public bool FreeTheBed(int patientId)
        {
            if(patientId == 1)
                return true;
            return false;
        }

        public PatientDataModel FetchPatientInfoFromBedId(string statusBedId)
        {
            PatientDataModel patient = new PatientDataModel();
            patient.PatientId = 1;
            patient.Mobile = "98989898989";
            patient.PatientName = "Hariram";
            patient.Address = "Indore";
            patient.Email = "hari@gmail.com";
            return patient;
        }
    }
}
