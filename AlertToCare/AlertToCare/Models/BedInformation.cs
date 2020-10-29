using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace AlertToCare.Models
{
    [ExcludeFromCodeCoverage]
    public class BedInformation
    {
        [Key]
        public string BedId { get; set; }
        public string WardNumber { get; set; }
        public int? PatientId { get; set; }
        [ForeignKey("PatientId")]
        public int BedInRow { get; set; }
        public int BedInColumn { get; set; }
    }
}
