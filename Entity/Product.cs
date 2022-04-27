using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity{
    public class Product{
        [Key]
        public int ProductID { get; set; }
        [Column(TypeName = "varchar(25)")]
        public string Description { get; set; }
        [Column(TypeName = "decimal(15,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string State { get; set; }
    }
}