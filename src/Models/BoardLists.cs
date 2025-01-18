using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wecore.Models
{
    public class BoardList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int Order { get; set; }

        [Required]
        public int BoardId { get; set; }

        [ForeignKey("BoardId")]
        public virtual Board Board { get; set; }

        public string Color { get; set; }

        public int WipLimit { get; set; }

        public bool IsArchived { get; set; }

        public DateTime CreatedAt { get; set; }

        public string CreatedById { get; set; }

        [ForeignKey("CreatedById")]
        public virtual ApplicationUser CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public string ModifiedById { get; set; }

        [ForeignKey("ModifiedById")]
        public virtual ApplicationUser ModifiedBy { get; set; }

        public virtual ICollection<Card> Cards { get; set; }

        public BoardList()
        {
            CreatedAt = DateTime.UtcNow;
            Cards = new HashSet<Card>();
            IsArchived = false;
        }
    }
}
