using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Employee
    {
        [Key]
        [Column (TypeName = "varchar(20)")]
        public string IdentificationCard { get; set; }
        [Column (TypeName = "varchar(25)")]
        public string Name { get; set; }
        [Column (TypeName = "varchar(25)")]
        public string LastName { get; set; }
        [Column (TypeName = "varchar(35)")]
        public string Address { get; set; }
        [Column (TypeName = "varchar(15)")]
        public string Phone { get; set; }
        [Column (TypeName = "varchar(25)")]
        public string Email { get; set; }
        [Column (TypeName = "varchar(20)")]
        public string Job { get; set; }
        [Column (TypeName = "varchar(10)")]
        public string State { get; set; }

    }
}
