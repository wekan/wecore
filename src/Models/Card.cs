using System;

namespace WeCore.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public int Order { get; set; }
        public int ColumnId { get; set; }
        public virtual Column Column { get; set; }
    }
}
