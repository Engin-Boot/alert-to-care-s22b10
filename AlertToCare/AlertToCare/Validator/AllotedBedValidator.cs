using AlertToCare.Models;

namespace AlertToCare.Validator
{
    public class AllotedBedValidator
    {
        private bool IsDepartmentNull(string department)
        {
            return department != null;
        }
        private bool IsPatientIdIsNull(int? patientId)
        {
            return patientId.HasValue;
        }
        public bool ValidateBedAlloted(BedAllotmentModel allotedBed)
        {
            bool isDepartmentNull = IsDepartmentNull(allotedBed.Department);
            bool isPatientIdIsNull = IsPatientIdIsNull(allotedBed.PatientId);

            if (isDepartmentNull == isPatientIdIsNull)
                return true;
            return false;
        }
    }
}
