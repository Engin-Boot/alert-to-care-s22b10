using System;
using System.Collections.Generic;
using System.Text;
using AlertToCare.Models;
using AlertToCare.Repository;

namespace AlertToCare.UnitTest.MockRepository
{
    class MockDeviceDataRepository : IMedicalDeviceDataRepository
    {
        public void InsertDevice(DeviceDataModel device)
        {
            if (device.DeviceName == "Oxymeter")
                throw new Exception("Exception");
        }

        public IEnumerable<string> Alert(MedicalStatusDataModel medicalStatus)
        {
            if (medicalStatus.BedId == "1B1")
                throw new ArgumentException("");
            if(medicalStatus.BedId == "1C1")
                throw new Exception("");
            var alertingDevice = new List<string>();
            alertingDevice.Add("Oxymeter");
            return alertingDevice;
        }
    }
}
