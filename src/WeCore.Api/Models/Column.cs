using System;

namespace WeCore.Api.Models
{
    public class Column
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public Guid BoardId { get; set; }
        public Board Board { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
