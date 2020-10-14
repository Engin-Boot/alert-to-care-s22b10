﻿using System.Collections.Generic;
using AlertToCare.Models;

namespace AlertToCare.BusinessLogic
{
    public interface IMedicalDeviceBusinessLogic
    {
        public void InsertDevice(MedicalDevice device);
        public IEnumerable<string> Alert(MedicalStatusDataModel medicalStatus);
        
    }
}
