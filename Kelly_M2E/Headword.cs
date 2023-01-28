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

        var splitters = new[] { ", ", ", or ", " or " };
        bool ContainsSplitter(string s) => splitters.Any(s.Contains);
        
        var headwords = new List<string>();
        var rest = inner;
        while (ContainsSplitter(rest) && IsValidEntry(rest.Split(splitters, StringSplitOptions.RemoveEmptyEntries)[0], headwords.Count == 0))
        {
            var rst = rest.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
            var toAdd = rst[0];
            headwords.Add(Normalise(toAdd));
            
            
            // find the splitter we used
            bool found = false;
            foreach (var splitter in splitters.Reverse()) // longest first. Avoids
            {
                if (!rest.StartsWith(toAdd + splitter)) continue;
                rest = rest.Substring(toAdd.Length + splitter.Length);
                found = true;
                break;
            }

            if (!found)
            {
                throw new InvalidOperationException("no substring");
            }
        }
        
        return new Headword(headwords.ToArray(), Entry: rest);
    }
}