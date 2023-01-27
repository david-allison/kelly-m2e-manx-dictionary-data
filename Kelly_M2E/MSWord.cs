using System.Text;

namespace Kelly_M2E;

public class MSWord
{
    public static string LoadEncodedFile(string resourceName)
    {
        return File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Resources", resourceName), Encoding.UTF8);
    }
}