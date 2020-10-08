using AlertToCare.Models;

namespace AlertToCare.Validator
{
    public class PatientValidator
    {
        internal static bool ValidatePatient(PatientDataModel patient)
        {
            if (patient.patientName != null && patient.email != null && patient.mobile != 0)
                return true;
            return false;
        }
    }
}
