using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okussakula.Model.Data
{
    public class Administrator
    {
        [Key]
        public long AdministratorId { get; set; }
        [Required]
        [ForeignKey("InstituitionId")]
        public long InstituitionId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Telephone { get; set; }
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        public DateTime DateInsert { get; set; }
        public DateTime DateUpdate { get; set; }
        public bool State { get; set; }

        public Instituition Instituition { get; set; }
    }
}
