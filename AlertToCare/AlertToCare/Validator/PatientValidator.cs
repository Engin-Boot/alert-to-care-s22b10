using AlertToCare.Models;

namespace AlertToCare.Validator
{
    public static class PatientValidator
    {
        private static bool IsStringIsNull(string word)
        {
            return (word == null);
        }

        private static bool IsLengthValid(string word)
        {
            return word.Length == 10;
        }
        internal static bool ValidatePatient(PatientDataModel patient)
        {
            if (IsStringIsNull(patient.PatientName) == IsStringIsNull(patient.Email) ==
                IsStringIsNull(patient.Mobile) == IsLengthValid(patient.Mobile) == false )
            {
                return true;
            }
            return false;
            /*if (patient.PatientName != null && patient.Email != null && patient.Mobile != null &&
                patient.Mobile.Length == 10)
                return true;*/
            
        }
    }
}
