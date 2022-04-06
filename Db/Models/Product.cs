namespace Dukkantek.Db.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Product")]
    public class Product
    {
        [Key]
        [Column("barcode")]
        [MaxLength(20)]
        public string Barcode { get; set; } = null!;

        [Column("name")]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Column("description", TypeName = "NVARCHAR(MAX)")]
        public string Description { get; set; } = null!;

        [Column("weight")]
        public float Weight { get; set; }

        [Column("status_id")]
        public ProductStatusId StatusId { get; set; }

        public ProductStatus Status { get; set; } = null!;

        [Column("category_id")]
        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
    }
}
