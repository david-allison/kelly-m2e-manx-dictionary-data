namespace Kelly_M2E;

/**
 * Keep in sync with CorpusSearch: KellyManxToEnglishEntry
 */
public class KellyManxToEnglishEntry
{
    public List<string> Words { get; set; }
    public string Definition { get; set; }
    public List<KellyManxToEnglishEntry> Children { get; set; } = new();
}