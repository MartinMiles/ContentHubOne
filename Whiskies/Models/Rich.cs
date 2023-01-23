namespace Whiskies.Models
{
    public class Rich
    {
        public string Type { get; set; }
        public List<Content> Content { get; set; }
    }

    public class Content
    {
        public string Type { get; set; }
        public List<Paragraph> content { get; set; }
    }

    public class Paragraph
    {
        public List<Marks> Marks { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
    }

    public class Marks
    {
        public string Type { get; set; }
        public Attrs Attrs { get; set; }
    }

    public class Attrs
    {
        public string Href { get; set; }
        public object Class { get; set; }
        public string Target { get; set; }
    }
}
