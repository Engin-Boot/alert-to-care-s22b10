using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AlertToCare.Models
{
    [ExcludeFromCodeCoverage]
    public class BedOnAlert
    {
        [Key]
        public string BedId { get; set; }
        [ForeignKey("DeviceName")]
        public string DeviceName { get; set; }
        public int Value { get; set; }
    }
}
