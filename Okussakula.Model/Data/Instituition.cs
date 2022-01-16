using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okussakula.Model.Data
{
    public class Instituition
    {
        [Key]
        public long InstituitionId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public string NIF { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Photo { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DateInsert { get; set; }
        public DateTime DateUpdate { get; set; }
        public bool State { get; set; }

        public ICollection<Administrator> Administrators { get; set; }
        public ICollection<InstituitionSpeciality> InstituitionSpeciality { get; set; }
        //public InstituitionSpeciality InstituitionSpecialityOne { get; set; }
        public ICollection<InstituitionExam> InstituitionExam { get; set; }
    }
}
