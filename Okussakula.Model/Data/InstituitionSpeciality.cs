using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okussakula.Model.Data
{
    public class InstituitionSpeciality
    {
        [Key]
        public long InstituitionSpecialityId { get; set; }

        [ForeignKey("InstituitionId")]
        public long InstituitionId { get; set; }

        [ForeignKey("SpecialityId")]
        public long SpecialityId { get; set; }

        public bool State { get; set; }
        public string Preco { get; set; }

        public Instituition Instituition { get; set; }
        public Speciality Speciality { get; set; }
    }
}
