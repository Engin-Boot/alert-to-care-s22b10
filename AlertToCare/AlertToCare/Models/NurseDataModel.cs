using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlertToCare.Models
{
    public class NurseDataModel
    {
        [Key]
        public string NurseId { get; set; }

        public string wardId { get; set; }

        public string NurseName { get; set; }
    }
}
