using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okussakula.Model.Data
{
    public class ConsultHorario
    {
        [Key]
        public long ConsultHorarioId { get; set; }
        [Required]
        [ForeignKey("CronogramConsultId")]
        public long CronogramConsultId { get; set; }
        [Required]
        public int Hora { get; set; }

        public bool State { get; set; }

        public CronogramConsult CronogramConsult { get; set; }
    }
}
