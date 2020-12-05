using System;

public static class ExtensionMethod
{
    internal static int CountChars(this string self)
    {
        int numbers = 0;
        foreach (char item in self)
        {
            numbers++;
        }

        return numbers;
    }

    public static bool TryBool(this string self)
    {
        return Boolean.TryParse(self, out var res) && res;
    }

    public static float TrySingle(this string self)
    {
        if (Single.TryParse(self, out var res))
        {
            return res;
        }
        return 0;
    }
}
