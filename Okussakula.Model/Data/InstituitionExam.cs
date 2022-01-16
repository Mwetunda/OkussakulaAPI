using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okussakula.Model.Data
{
    public class InstituitionExam
    {
        [Key]
        public long InstituitionExamId { get; set; }

        [ForeignKey("InstituitionId")]
        public long InstituitionId { get; set; }

        [ForeignKey("ExamId")]
        public long ExamId { get; set; }

        public bool State { get; set; }
        public string Preco { get; set; }

        public Instituition Instituition { get; set; }
        public Exam Exam { get; set; }

    }
}
