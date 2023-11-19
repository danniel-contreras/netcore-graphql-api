using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public required string Name { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public required string Description { get; set; }
        [Required]
        [Column(TypeName = "float(10,2)")]
        public float Price { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public required virtual Category Category { get; set; }
    }
}