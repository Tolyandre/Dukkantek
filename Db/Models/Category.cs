namespace Dukkantek.Db.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Category")]
    public class Category
    {
        [Column("category_id")]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        public List<Product> Products { get; set; } = null!;
    }
}
