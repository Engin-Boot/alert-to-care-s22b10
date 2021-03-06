﻿using AlertToCare.Models;
using System.Collections.Generic;

namespace AlertToCare.Repository
{
    public interface IMedicalDeviceDataRepository
    {
        public MedicalDevice FetchMedicalDevice(string deviceName);
        public void InsertMedicalDevice(MedicalDevice medicalDevice);
        public void TurnOnAlert(BedOnAlert bed);
        BedInformation FetchBedLayoutInfo(string bedId);
        void TurnOffAlert(string bedId);
        public IEnumerable<BedOnAlert> GetAllAlerts(string wardNumber);
        public bool RaiseAlert(string bedId, string device, int value);
    }
}
