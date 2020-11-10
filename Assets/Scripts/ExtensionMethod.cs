public static class ExtensionMethod
{
    public static int CountChars(this string self)
    {
        int numbers = 0;
        foreach (char item in self)
        {
            numbers++;
        }

        return numbers;
    }
}
