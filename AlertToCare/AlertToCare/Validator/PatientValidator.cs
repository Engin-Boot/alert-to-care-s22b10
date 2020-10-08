using AlertToCare.Models;

namespace AlertToCare.Validator
{
    public static class PatientValidator
    {
        internal static bool ValidatePatient(PatientDataModel patient)
        {
            if (patient.PatientName != null && patient.Email != null && patient.Mobile != null &&
                patient.Mobile.Length == 10)
                return true;
            return false;
        }
    }
}
