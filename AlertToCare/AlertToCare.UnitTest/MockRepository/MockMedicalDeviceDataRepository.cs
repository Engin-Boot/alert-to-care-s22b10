using AlertToCare.Models;
using AlertToCare.Repository;

namespace AlertToCare.UnitTest.MockRepository
{
    class MockMedicalDeviceDataRepository: IMedicalDeviceDataRepository
    {
        public MedicalDevice FetchMedicalDevice(string deviceName)
        {
            if (deviceName != "Oxymeter")
                return null;
            var device = new MedicalDevice {DeviceName = "Oxymeter", MaxValue = 60, MinValue = 20};
            return device;
        }

        public void InsertMedicalDevice(MedicalDevice medicalDevice)
        {
            
        }

        public void TurnOnAlert(BedOnAlert bed)
        {
            
        }
    }
}
