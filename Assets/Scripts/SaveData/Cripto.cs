using System;

namespace ShipovMihail_Roll_A_Boll
{
    public static class Cripto
    {
        public static string CryptoXOR(string text, int key = 42)
        {
            var result = String.Empty;
            foreach (var simbol in text)
            {
                result += (char)(simbol ^ key);
            }
            return result;
        }
    }
}
