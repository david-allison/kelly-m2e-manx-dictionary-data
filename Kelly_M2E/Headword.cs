using HtmlAgilityPack;

namespace Kelly_M2E;

public record Headword(string[] HeadWords, string Entry)
{
    public static Headword? FromHtml(HtmlNode html)
    {
        var htmlString = html.InnerHtml.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ");
        var inner = html.InnerText.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ");

        var headwords = new List<string>();
        var rest = inner;
        while (rest.Contains(',') && rest.Split(",")[0].HasUpperCaseWordsGreaterThanLength1())
        {
            headwords.Add(rest.Split(",")[0]);
            rest = string.Join(",", rest.Skip(1));
        }
        
        return new Headword(headwords.ToArray(), Entry: rest);
    }
}