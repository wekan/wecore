using System;
using System.Collections.Generic;

namespace WeCore.Api.Models
{
    public class BoardList
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid BoardId { get; set; }
        public Board Board { get; set; }
        public int Order { get; set; }
        public ICollection<Card> Cards { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
