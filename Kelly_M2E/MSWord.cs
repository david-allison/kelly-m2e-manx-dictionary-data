using System.Text;

namespace Kelly_M2E;

public class MSWord
{
    public static string LoadEncodedFile(string resourceName)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        Encoding wind1252 = Encoding.GetEncoding(1252);
        // 1252 encoded :/
        return File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Resources", resourceName), wind1252);
    }
}