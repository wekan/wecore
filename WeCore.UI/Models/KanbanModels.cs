namespace WeCore.UI.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public List<Swimlane> Swimlanes { get; set; } = new();
        public int Order { get; set; }
    }

    public class Swimlane
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public List<List> Lists { get; set; } = new();
        public int Order { get; set; }
    }

    public class List
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public List<Card> Cards { get; set; } = new();
        public int Order { get; set; }
    }

    public class Card
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public int Order { get; set; }
    }
}
