using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeCore.Api.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Title { get; set; }

        public required string Description { get; set; }

        public bool IsArchived { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public required string CreatedById { get; set; }
        public required virtual ApplicationUser CreatedBy { get; set; }

        public required virtual ICollection<BoardList> Lists { get; set; } = new List<BoardList>();
        public required virtual ICollection<BoardMember> Members { get; set; } = new List<BoardMember>();
    }
}
