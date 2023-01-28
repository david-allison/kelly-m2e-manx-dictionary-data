// See https://aka.ms/new-console-template for more information

using HtmlAgilityPack;
using Kelly_M2E;
using Newtonsoft.Json;

void Print(IEnumerable<Headword> enumerable)
{
    foreach (var headword in enumerable)
    {
        var hw = headword.HeadWords.Length == 0 ? "[missing]" : String.Join(" | ", headword.HeadWords);
        Console.WriteLine(hw + "|\t" + headword.Entry);
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

var hasLowercaseInHeadword = headwords.Where(x => x.HeadWords.Any(x => x.Any(char.IsLower))).ToList();
Console.WriteLine(hasLowercaseInHeadword.Count() + " problems");

if (!hasNoHeadWord.Any()) {
    var isInvalid = headwords.Where(x => x.HeadWords[0] == "AAA").ToList();
    if (isInvalid.Any() )
    {
        Print(isInvalid);
    }
}

Print(hasWordInDefinition);
//Print(hasLowercaseInHeadword);
//Print(hasNoHeadWord);
//Print(headwords);

var output = headwords.Select(x => new KellyManxToEnglishEntry
{
    Words = x.HeadWords.ToList(),
    Definition = x.Entry
});

File.WriteAllText("kelly-v1.json", JsonConvert.SerializeObject(output, Formatting.Indented));