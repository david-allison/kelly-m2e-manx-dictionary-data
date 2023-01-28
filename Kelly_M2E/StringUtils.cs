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
        
        return entry.Any(x => x.IsUpperCase(allowOne: allowOne));
    }

    public static bool AreAllWordsUpperCase(this string s, bool allowOne = false)
    {
        var entry = s.Split(" ");

        if (entry.Length == 1 && allowOne)
        {
            return entry[0] == entry[0].ToUpperInvariant(); // if 1 char and upper - return true
        }
        
        return entry.All(x => x.IsUpperCase(allowOne: allowOne));
    }
    
    public static bool IsUpperCase(this string s, bool allowOne = false)
    {
        s = s.Trim().Trim(';').Trim('.').Trim(',');
        return (allowOne || s.Length > 1) && s.Where(char.IsAscii).All(x => !char.IsLower(x) && !char.IsNumber(x));
    }
}