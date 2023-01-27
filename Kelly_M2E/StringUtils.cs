namespace Kelly_M2E;

public static class StringUtils
{
    public static bool HasUpperCaseWordsGreaterThanLength1(this string s)
    {
        var entry = s.Split(" ");
        return entry.Any(x => x.Length > 1 && x.All(char.IsUpper));
    }
}