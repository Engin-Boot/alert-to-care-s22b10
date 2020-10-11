using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Repository
{
    public interface IMedicalDeviceDataRepository
    {
        public void InsertDevice(Models.DeviceDataModel device);
        public IEnumerable<string> Alert(Models.MedicalStatusDataModel medicalStatus);
    }
}
