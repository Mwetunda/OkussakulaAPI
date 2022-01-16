using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okussakula.Model.Data
{
    public class CronogramExam
    {
        [Key]
        public long CronogramExamId { get; set; }
        [Required]
        [ForeignKey("InstituitionExamId")]
        public long InstituitionExamId { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public double Preco { get; set; }
        [Required]
        public string Observacao { get; set; }

        public InstituitionExam InstituitionExam { get; set; }
    }
}
