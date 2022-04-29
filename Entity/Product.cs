using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity{
    public class Product{
        [Key]
        [Column(TypeName = "nvarchar(15)")]
        public string ProductID { get; set; }
        [Column(TypeName = "nvarchar(25)")]
        public string Description { get; set; }
        [Column(TypeName = "decimal(15,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }
        [Column(TypeName = "nvarchar(15)")]
        public string State { get; set; }
    }
}