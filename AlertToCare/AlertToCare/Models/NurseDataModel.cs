using System.ComponentModel.DataAnnotations;


namespace AlertToCare.Models
{
    public class NurseDataModel
    {
        [Key]
        public string NurseId { get; set; }

        public string WardId { get; set; }

        public string NurseName { get; set; }
    }
}
