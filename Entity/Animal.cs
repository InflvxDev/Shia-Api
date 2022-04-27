using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Animal
    {
        [Key]
        public int AnimalID { get; set; }
        [Column (TypeName = "varchar(25)")]
        public string Name { get; set; }
        [Column (TypeName = "varchar(100)")]
        public string Description { get; set; }
        [Column (TypeName = "varchar(20)")]
        public string Type { get; set; }
        [Column (TypeName = "varchar(20)")]
        public string Breed { get; set; }
        public int Age { get; set; }
        [Column (TypeName = "varchar(10)")]
        public string Gender {get; set;}
        [Column (TypeName = "varchar(10)")]
        public string State { get; set; }

    }
}
