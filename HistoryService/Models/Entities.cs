using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HistoryService.Models
{
    [Table("Quantity")]
    public class QuantityMeasurementEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public double Value1 { get; set; }

        [Required]
        public double Value2 { get; set; }

        [Required]
        public string Unit1 { get; set; } = string.Empty;

        [Required]
        public string Unit2 { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Operation { get; set; } = string.Empty;

        [Required]
        public double Result { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
