using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AlertToCare.Models
{
    [ExcludeFromCodeCoverage]
    public class MedicalStatusDataModel
    {
        public string BedId { get; set; }
        public IDictionary<string, int> MedicalDevice { get; set; }
    }
}
