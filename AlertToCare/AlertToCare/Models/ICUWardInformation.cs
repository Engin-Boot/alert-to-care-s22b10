using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AlertToCare.Models
{
    [ExcludeFromCodeCoverage]
    public class IcuWardInformation
    {
        [Key]
        public string WardNumber { get; set; }
        public int TotalBed { get; set; }
        public string Department { get; set; }
    }
}
