// See https://aka.ms/new-console-template for more information

using Kelly_M2E;

Console.WriteLine("Hello, World!");

string resourceName = "Fockleyr J Kelly m2e_CORR_clean.html";

var docText = MSWord.LoadEncodedFile(resourceName);

Console.WriteLine(docText);