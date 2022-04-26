using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Enterprise
    {
        [Key]
        public int Nit { get; set; }
        [Column (TypeName = "varchar(20)")]
        public string Name { get; set; }
        [Column (TypeName = "varchar(25)")]
        public string Email { get; set; }
        [Column (TypeName = "varchar(15)")]
        public string Phone { get; set; }
        [Column (TypeName = "varchar(35)")]
        public string Address { get; set; }
    }
}
