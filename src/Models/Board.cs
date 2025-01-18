using System;
using System.Collections.Generic;

namespace WeCore.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public virtual ICollection<Column> Columns { get; set; }
    }
}
