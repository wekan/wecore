using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeCore.Api.Models
{
    public class Label
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Color { get; set; }

        public int BoardId { get; set; }
        public virtual Board Board { get; set; }

        public virtual ICollection<CardLabel> Cards { get; set; }
    }
}
