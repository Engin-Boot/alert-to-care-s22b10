using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AlertToCare.Models
{
    [ExcludeFromCodeCoverage]
    public class MedicalDevice
    {
        [Key]
        public string DeviceName { get; set; }
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}
