using HtmlAgilityPack;

namespace Kelly_M2E;

public record Headword(string[] HeadWords, string Entry)
{
    public static Headword? FromHtml(HtmlNode html)
    {
        var htmlString = html.InnerHtml.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ");
        var inner = html.InnerText.Replace("\r\n", " ").Replace("\n", " ").Replace("\r", " ");

        bool IsValidEntry(string s, bool allowOne)
        {
            if (s.Replace(", or ", "").Replace(" or ", "").HasUpperCaseWordsGreaterThanLength1(allowOne))
            {
                return true;
            }

            return false;
        }

        string Normalise(string s)
        {
            return s.Replace(", or ", "").Replace(" or ", "");
        }
        
        var headwords = new List<string>();
        var rest = inner;
        while (rest.Contains(',') && IsValidEntry(rest.Split(",")[0], headwords.Count == 0))
        {
            var toAdd = rest.Split(",")[0];
            headwords.Add(Normalise(toAdd));
            rest = string.Join(",", rest.Skip(1));
        }
        
        return new Headword(headwords.ToArray(), Entry: rest);
    }
}