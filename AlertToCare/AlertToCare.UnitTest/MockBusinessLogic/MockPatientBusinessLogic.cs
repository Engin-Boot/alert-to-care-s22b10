using System;
using AlertToCare.BusinessLogic;
using AlertToCare.Models;

namespace AlertToCare.UnitTest.MockBusinessLogic
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
            PatientDataModel patient = new PatientDataModel
            {
                PatientId = 1,
                Mobile = "98989898989",
                PatientName = "Hariram",
                Address = "Indore",
                Email = "hari@gmail.com"
            };
            return patient;
        }

        public PatientDataModel FetchPatientInfo(int patientId)
        {
            var patient = new PatientDataModel
            {
                PatientId = patientId, Address = "addr", Mobile = "9090909090", Email = "email@email.com"
            };
            return patient;
        }

        Tuple<PatientDataModel, BedInformation> IPatientBusinessLogic.AllotBedToPatient(BedAllotmentModel allotBed)
        {
            if(allotBed.PatientId ==2)
                throw new Exception();
            var objPatientInfo = new PatientDataModel();
            var objBedInfo = new BedInformation();
            return new Tuple<PatientDataModel, BedInformation>(objPatientInfo, objBedInfo);
        }

        public void AllotBed(PatientDataModel patient, string wardId, string bedId)
        {
            throw new NotImplementedException();
        }
    }
}
