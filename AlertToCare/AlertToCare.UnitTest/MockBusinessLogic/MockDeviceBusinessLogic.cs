using System;
using System.Collections.Generic;
using System.Linq;
using AlertToCare.BusinessLogic;
using AlertToCare.Models;

namespace AlertToCare.UnitTest.MockBusinessLogic
{
    class MockDeviceBusinessLogic : IMedicalDeviceBusinessLogic
    {
        public void InsertDevice(MedicalDevice device)
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
            var alertingDevice = new List<string> {"Oxymeter"};
            return alertingDevice;
        }

        public int[] FetchBedLayoutInfo(string statusBedId)
        {
            int[] result = {2, 2};
            return result;
        }

        public void AlertOff(string bedId)
        {
            if(bedId == "1F1")
                throw new Exception("");
        }

        public IEnumerable<BedOnAlert> getAllAlerts(string wardNumber)
        {
            var bed1 = new BedOnAlert();
            var bed2 = new BedOnAlert();
            IEnumerable<BedOnAlert> list= new List<BedOnAlert>();
            list.Append(bed1);
            list.Append(bed2);
            return list;
            
        }

        public bool raiseAlert(string bedId, string device, int value)
        {
            throw new NotImplementedException();
        }
    }
}
