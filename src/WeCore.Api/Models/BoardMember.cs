using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeCore.Api.Models
{
    public class BoardMember
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int BoardId { get; set; }

        [Required]
        public required string UserId { get; set; }

        public bool IsAdmin { get; set; }

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("BoardId")]
        public required virtual Board Board { get; set; }

        [ForeignKey("UserId")]
        public required virtual User User { get; set; }
    }
}
