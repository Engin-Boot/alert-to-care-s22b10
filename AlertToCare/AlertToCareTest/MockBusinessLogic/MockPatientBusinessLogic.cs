using System;
using AlertToCare.BusinessLogic;
using AlertToCare.Models;
using AlertToCare.Repository;

namespace AlertToCare.UnitTest.MockRepository
{
    class MockPatientBusinessLogic: IPatientBusinessLogic
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

        public void AllotBedToPatient(BedAllotmentModel allotBed)
        {
            if(allotBed.PatientId ==2)
                throw new Exception("");
        }

        public void FreeTheBed(int patientId)
        {
            if(patientId == 2)
                throw new Exception("");
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
