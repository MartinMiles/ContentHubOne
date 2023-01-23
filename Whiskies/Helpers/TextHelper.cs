using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Whiskies.Helpers
{
    public static class TextHelper
    {
        public static IHtmlContent ToParagraphs(this IHtmlHelper htmlHelper, string text)
        {
            var modifiedText = text.Replace("\n", "<br>");
            var p = new TagBuilder("p");
            p.InnerHtml.AppendHtml(modifiedText);
            return p;
        }
    }
}
    