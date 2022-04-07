using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dukkantek.Db.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProductStatusId : int
    {
        Sold = 0,
        InStock = 1,
        Damaged = 2,
    }

    [Table("ProductStatus")]
    public class ProductStatus
    {
        [Column("product_status_id")]
        [Key]
        public ProductStatusId Id { get; set; }

        [Column("name")]
        [MaxLength(15)]
        public string Name { get; set; } = null!;
    }
}
