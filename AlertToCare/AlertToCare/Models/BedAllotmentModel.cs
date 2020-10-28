using System.Diagnostics.CodeAnalysis;
namespace AlertToCare.Models
{
    [ExcludeFromCodeCoverage]
    public class BedAllotmentModel
    {
        public int PatientId { get; set; }
        public string Department { get; set; }
    }
}
