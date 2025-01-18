using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeCore.Api.Models
{
    public class CardActivity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CardId { get; set; }

        [Required]
        public required string UserId { get; set; }

        [Required]
        public required string ActivityType { get; set; }

        public required string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("CardId")]
        public required virtual Card Card { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
