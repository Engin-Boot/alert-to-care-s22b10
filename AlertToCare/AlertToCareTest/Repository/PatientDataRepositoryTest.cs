using System.Linq;
using AlertToCare.Models;
using AlertToCare.Repository;
using Xunit;

namespace AlertToCare.UnitTest.Repository
{
    public class PatientDataRepositoryTest: InMemoryContext
    {
        [Fact]
        public void TestAddPatientSuccessful()
        {
            var dummyPatient = new PatientDataModel
            {
                PatientName = "Patient1", 
                Address = "Address", 
                Mobile = "98989898989",
                Email = "P1@mail.com"
            };
            var patientData  = new PatientDataRepository(_context);
            patientData.AddPatient(dummyPatient);
            var patientDataInDb = _context.PatientInfo.First
                (p => p.PatientName == "Patient1");
            Assert.NotNull(patientDataInDb);
        }
        [Fact]
        public void TestFetchPatientInfoFromBedIdReturnsNullForBedIdNotExists()
        {
            var patientData = new PatientDataRepository(_context);
            var response = patientData.FetchPatientInfoFromBedId("1B1");
            Assert.Null(response);
        }
        [Fact]
        public void TestFetchPatientInfoFromBedIdReturnsBedObjectForBedIdExists()
        {
            var patientData = new PatientDataRepository(_context);
            var response = patientData.FetchPatientInfoFromBedId("1A1");
            Assert.NotNull(response);
        }

        [Fact]
        public void TestFreeTheBedRemovePatientEntry()
        {
            var patientData = new PatientDataRepository(_context);
            var bed = _context.BedInformation.First
                (p => p.PatientId == 1);
            patientData.RemovePatientFromBed(1);
            Assert.Null(bed.PatientId);
        }
        
    }
}
