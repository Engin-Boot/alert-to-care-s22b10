using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare.Models;
using AlertToCare.Utility;

namespace AlertToCare.Validator
{
    public static class DeviceValidator
    {
        public static bool ValidateDevice(MedicalDevice device)
        {
            if (Utils.IsValueNull(device.DeviceName) == false && device.MaxValue > device.MinValue)
            {
                return true;
            }
            return false;
        }
    }
}
