using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okussakula.Model.Data
{
    public class Exam
    {
        [Key]
        public long ExamId { get; set; }
        [Required]
        public string Designation { get; set; }
        public bool State { get; set; }
    }
}
