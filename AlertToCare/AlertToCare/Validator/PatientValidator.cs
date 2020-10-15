using AlertToCare.Models;
using static AlertToCare.Validator.Utils;

namespace AlertToCare.Validator
{
    public static class PatientValidator
    {   
        internal static bool ValidatePatient(PatientDataModel patient)
        {
            if (IsValueNull(patient.PatientName) == IsValueNull(patient.Email) ==
                IsValueNull(patient.Mobile) == IsLengthValid(patient.Mobile, 10) == false )
            {
                return true;
            }
            return false;
        }
    }
}