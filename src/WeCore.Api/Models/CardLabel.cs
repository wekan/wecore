using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeCore.Api.Models
{
    public class CardLabel
    {
        [Key]
        public int Id { get; set; }

        public int CardId { get; set; }
        
        public int LabelId { get; set; }

        [ForeignKey("CardId")]
        public required virtual Card Card { get; set; }

        [ForeignKey("LabelId")]
        public required virtual Label Label { get; set; }
    }
}
