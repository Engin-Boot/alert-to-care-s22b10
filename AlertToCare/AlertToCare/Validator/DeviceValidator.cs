using AlertToCare.Models;
using static AlertToCare.Validator.Utils;

namespace AlertToCare.Validator
{
    public static class DeviceValidator
    {
        public static bool ValidateDevice(MedicalDevice device)
        {
            if (IsValueNull(device.DeviceName) == false && device.MaxValue > device.MinValue)
            {
                return true;
            }
            return false;
        }
    }
}
