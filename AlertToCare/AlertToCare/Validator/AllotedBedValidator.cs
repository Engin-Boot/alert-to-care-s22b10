using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertToCare.Models;

namespace AlertToCare.Validator
{
    public class AllotedBedValidator
    {
        public bool ValidateBedAlloted(BedAllotmentModel allotedBed)
        {
            int? patientId = allotedBed.PatientId;
            if (allotedBed.Department != null && patientId.HasValue)
                return true;
            return false;
        }
    }
}
