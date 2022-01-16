using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okussakula.Model.Data
{
    public class Consult
    {
        [Key]
        public long ConsultId { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public long UserId { get; set; }
        [Required]
        [ForeignKey("ConsultHorarioId")]
        public long ConsultHorarioId { get; set; }
        public DateTime DataInsert { get; set; }
        public DateTime DataUpdate { get; set; }

        [MaxLength(150)]
        public string Descricao { get; set; }

        public bool State { get; set; }

        public User User { get; set; }
        public ConsultHorario ConsultHorario { get; set; }
    }
}
