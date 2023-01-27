// See https://aka.ms/new-console-template for more information

using HtmlAgilityPack;
using Kelly_M2E;

Console.WriteLine("Hello, World!");

string resourceName = "Fockleyr J Kelly m2e_CORR_clean.html";

var docText = MSWord.LoadEncodedFile(resourceName);

var doc = new HtmlDocument();
doc.LoadHtml(docText);

var headwords = doc.DocumentNode.Descendants("p")
    .Select(Headword.FromHtml)
    .Where(x => x != null)
    .Select(x => x!)
    .ToList();
    
var invalid = headwords.Where(x => x.Entry.HasUpperCaseWordsGreaterThanLength1());

foreach (var headword in invalid)
{
    //Console.WriteLine(headword.HeadWords[0]);
    Console.WriteLine(headword.Entry);
}

Console.WriteLine(invalid.Count() + " problems");