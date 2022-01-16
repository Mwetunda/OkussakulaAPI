using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okussakula.Model.Data
{
    public class CronogramConsult
    {
        [Key]
        public long CronogramConsultId { get; set; }
        [Required]
        [ForeignKey("InstituitionSpecialityId")]
        public long InstituitionSpecialityId { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public double Preco { get; set; }
        [Required]
        public string Observacao { get; set; }

        public InstituitionSpeciality InstituitionSpeciality { get; set; }
        public ICollection<ConsultHorario> ConsultHorarios{ get; set; }
    }
}
