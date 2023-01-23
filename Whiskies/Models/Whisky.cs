namespace Whiskies.Models
{
    public class Whisky
    {
        public string id { get; set; }
        public string Vendor { get; set; }
        public string Brand { get; set; }
        public int? Years { get; set; }
        public string Description { get; set; }
        public Media Picture { get; set; }
        public Media Video { get; set; }
    }

    public class Media
    {
        public List<PictureResult> Results { get; set; }
    }

    public class PictureResult
    {
        public string FileUrl { get; set; }
        public string Name { get; set; }
    }
}
