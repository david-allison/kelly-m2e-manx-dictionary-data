// See https://aka.ms/new-console-template for more information

using HtmlAgilityPack;
using Kelly_M2E;

void Print(IEnumerable<Headword> enumerable)
{
    foreach (var headword in enumerable)
    {
        Console.WriteLine(headword.HeadWords[0] + "\t" + headword.Entry);
    }
}

string resourceName = "Fockleyr J Kelly m2e_CORR_clean.html";

var docText = MSWord.LoadEncodedFile(resourceName);

var doc = new HtmlDocument();
doc.LoadHtml(docText);

PreprocessUpperCase(doc);

void PreprocessUpperCase(HtmlDocument htmlDocument)
{
    // all font variants involve small caps
    var nodes = htmlDocument.DocumentNode.SelectNodes("//span[contains(@style, 'font-variant:')]");
    foreach (var node in nodes)
    {
        node.InnerHtml = node.InnerHtml.ToUpper();
    }
}

var headwords = doc.DocumentNode.Descendants("p")
    .Select(Headword.FromHtml)
    .Where(x => x != null)
    .Select(x => x!)
    .ToList();
    
var hasWordInDefinition = headwords.Where(x => x.Entry.HasUpperCaseWordsGreaterThanLength1()).ToList();
Console.WriteLine(hasWordInDefinition.Count() + " problems");

var hasNoHeadWord = headwords.Where(x => x.HeadWords.Length == 0).ToList();
Console.WriteLine(hasNoHeadWord.Count() + " problems");
//
// foreach (var word in headwords)
// {
//     Console.WriteLine(word.HeadWords[0] + "\t" + word.Entry);
// }

Print(headwords);