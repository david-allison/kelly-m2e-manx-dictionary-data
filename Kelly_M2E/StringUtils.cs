namespace Kelly_M2E;

public static class StringUtils
{
    public static bool HasUpperCaseWordsGreaterThanLength1(this string s, bool allowOne = false)
    {
        var entry = s.Split(" ");

        if (entry.Length == 1 && allowOne)
        {
            return entry[0] == entry[0].ToUpperInvariant(); // if 1 char and upper - return true
        }
        
        return entry.Any(x => x.Length > 1 && x.Where(char.IsAscii).All(x => char.IsUpper(x) || x == '-' || x == '!'));
    }
}