using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okussakula.Model.Data
{
    public class ExamHorario
    {
        [Key]
        public long ExamHorarioId { get; set; }
        [Required]
        [ForeignKey("CronogramExamId")]
        public long CronogramExamId { get; set; }
        [Required]
        public int Hora { get; set; }

        public bool State { get; set; }

        public CronogramExam CronogramExam { get; set; }
    }
}
