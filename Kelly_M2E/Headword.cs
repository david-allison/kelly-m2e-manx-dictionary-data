using HtmlAgilityPack;

namespace Kelly_M2E;

public class Headword
{
    public static Headword? FromHtml(HtmlNode html)
    {
        Console.WriteLine(html.InnerText.Replace("\r", " ").Replace("\n", " "));
        return null;
    }
}