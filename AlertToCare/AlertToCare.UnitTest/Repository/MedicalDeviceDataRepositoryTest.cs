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
            var deviceData = new MedicalDeviceDataRepository(Context);
            MedicalDevice device = new MedicalDevice {DeviceName = "Oxymeter", MinValue = 90, MaxValue = 120};
            deviceData.InsertMedicalDevice(device);
            var deviceInDb = Context.MedicalDevice.First
                (p => p.DeviceName == "Oxymeter");
            Assert.NotNull(deviceInDb);
        }

        [Fact]
        public void TestFetchDeviceSuccessful()
        {
            var deviceData = new MedicalDeviceDataRepository(Context);
            deviceData.FetchMedicalDevice("TestDevice");
            Assert.NotNull(deviceData);
        }
        [Fact]
        public void TestTurnOnAlertSuccessful()
        {
            var deviceData = new MedicalDeviceDataRepository(Context);
            var bed = new BedOnAlert {BedId = "1A1", DeviceName = "Oxymeter", Value = 90};
            deviceData.TurnOnAlert(bed);
            var deviceInDb = Context.BedOnAlert.First
                (p => p.DeviceName == "Oxymeter");
            Assert.NotNull(deviceInDb);
        }
    }
}
