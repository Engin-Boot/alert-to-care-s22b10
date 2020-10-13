using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare.Models;

namespace AlertToCare.Repository
{
    public interface IMedicalDeviceDataRepository
    {
        public MedicalDevice FetchMedicalDevice(string deviceName);
        public void InsertMedicalDevice(MedicalDevice medicalDevice);
        public void TurnOnAlert(BedOnAlert bed);
    }
}
