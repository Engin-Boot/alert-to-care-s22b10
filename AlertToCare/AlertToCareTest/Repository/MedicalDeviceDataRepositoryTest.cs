using System.Linq;
using AlertToCare.Models;
using AlertToCare.Repository;
using Xunit;

namespace AlertToCare.UnitTest.Repository
{
    public class MedicalDeviceDataRepositoryTest : InMemoryContext
    {
        [Fact]
        public void TestInsertDeviceSuccessful()
        {
            var deviceData = new MedicalDeviceDataRepository(_context);
            MedicalDevice device = new MedicalDevice {DeviceName = "Oxymeter", MinValue = 90, MaxValue = 120};
            deviceData.InsertMedicalDevice(device);
            var deviceInDb = _context.MedicalDevice.First
                (p => p.DeviceName == "Oxymeter");
            Assert.NotNull(deviceInDb);
        }

        [Fact]
        public void TestFetchDeviceSuccessful()
        {
            var deviceData = new MedicalDeviceDataRepository(_context);
            deviceData.FetchMedicalDevice("TestDevice");
            Assert.NotNull(deviceData);
        }
        [Fact]
        public void TestTurnOnAlertSuccessful()
        {
            var deviceData = new MedicalDeviceDataRepository(_context);
            var bed = new BedOnAlert {BedId = "1A1", DeviceName = "Oxymeter", Value = 90};
            deviceData.TurnOnAlert(bed);
            var deviceInDb = _context.BedOnAlert.First
                (p => p.DeviceName == "Oxymeter");
            Assert.NotNull(deviceInDb);
        }
    }
}
