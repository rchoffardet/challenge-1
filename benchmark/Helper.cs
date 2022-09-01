public static class Helper
{
    public static void Deconstruct<T>(this T[] arr, out T first, out T second, out T third)
    {
        first = arr[0];
        second = arr[1];
        third = arr[2];
    }
    
    public static string Humanize(this TimeSpan duration)
    {
        if(duration.TotalMicroseconds < 1000) 
            return $"{Math.Round(duration.TotalMicroseconds, 3)} μs";

        if(duration.TotalNanoseconds < 1000) 
            return $"{Math.Round(duration.TotalNanoseconds, 3)} ns";

        if(duration.TotalMilliseconds < 1000) 
            return $"{Math.Round(duration.TotalMilliseconds, 3)} ms";

         return $"{Math.Round(duration.TotalSeconds, 3)} s";
    }

    public static string Humanize(this float nb, string unit = "")
    {
        return Humanize((double) nb, unit);
    }

    public static string Humanize(this long nb, string unit = "")
    {
        return Humanize((double) nb, unit);
    }

    public static string Humanize(this double nb, string unit = "")
    {
        var space = unit == "" ? "" : " ";

        if(nb < 1_000) 
            return $"{nb}";

        if(nb < 1_000_000) 
            return $"{Math.Round(nb/1_000, 3)}{space}K{unit}";

        if(nb < 1_000_000_000) 
            return $"{Math.Round(nb/1_000_000, 3)}{space}M{unit}";

         return $"{Math.Round(nb/1_000_000_000, 3)}{space}G{unit}";
    }
}
