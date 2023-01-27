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