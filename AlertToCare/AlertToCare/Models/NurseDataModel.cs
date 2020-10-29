using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AlertToCare.Models
{
    [ExcludeFromCodeCoverage]
    public class NurseDataModel
    {
        [Key]
        public string NurseId { get; set; }

        public string WardId { get; set; }

        public string NurseName { get; set; }
    }
}
