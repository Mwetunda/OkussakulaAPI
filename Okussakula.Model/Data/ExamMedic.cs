using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okussakula.Model.Data
{
    public class ExamMedic
    {
        [Key]
        public long ExamMedicId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public long UserId { get; set; }
        [Required]
        [ForeignKey("ExamHorarioId")]
        public long ExamHorarioId { get; set; }
        public DateTime DataInsert { get; set; }
        public DateTime DataUpdate { get; set; }

        [MaxLength(150)]
        public string Descricao { get; set; }

        public bool State { get; set; }

        public User User { get; set; }
        public ExamHorario ExamHorario { get; set; }
    }
}
