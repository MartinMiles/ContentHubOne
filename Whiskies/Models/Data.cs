namespace Whiskies.Models
{
    public class Data
    {
        public Collection Collection { get; set; }
        public Whisky pdp { get; set; }
    }

    public class Collection
    {
        public string Intro { get; set; }
        public Rich Rich { get; set; }
        public Media Archive { get; set; }
        public Items Items { get; set; }
    }

    public class Items
    {
        public List<Whisky> Results { get; set; }
    }
}
