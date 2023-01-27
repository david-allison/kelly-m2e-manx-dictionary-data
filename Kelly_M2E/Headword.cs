using HtmlAgilityPack;

namespace Kelly_M2E;

public record Headword(string[] HeadWords, string Entry)
{
    public static Headword? FromHtml(HtmlNode html)
    {
        var htmlString = html.InnerHtml.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ");
        var inner = html.InnerText.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ");

        var split = inner.Split(",");
        var headword = split[0];
        var rest = string.Join(",", split.Skip(1));
        
        
        var headwords = new[] { headword };
        return new Headword(headwords, Entry: rest);
    }
}