namespace BetFor.Helpers
{
    public static class Converter
    {
        public static long ToLongFromString(string value)
        {
            if (!long.TryParse(value, out long number))
            {
                number = 0;
            }

            return number;
        }
    }
}