using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Adopter
    {
        [Key]
        [Column(TypeName = "nvarchar(20)")]
        public string IdentificationCard { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string LastName { get; set; }
        [Column(TypeName = "nvarchar(35)")]
        public string Address { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string State { get; set; }
    }
}