public static class Chapter1
{
  public static void StringInterpolation()
  {
    var arr = new int[] { 3, 1, 4, 1, 5 };
    Console.WriteLine($"doubled array: {string.Join(", ", arr.Select(x => x * 2))}");
  }

  public static void FormatWithCultureInfo()
  {
    Func<FormattableString, string> toSpanishSpain = (src) =>
      string.Format(
          System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"),
          src.Format,
          src.GetArguments());

    Func<FormattableString, string> toEnglishAustralia = (src) =>
      string.Format(
          System.Globalization.CultureInfo.CreateSpecificCulture("en-AU"),
          src.Format,
          src.GetArguments());

    FormattableString s = $"Current time is {DateTime.Now}";
    Console.WriteLine($"ja-JP: {s}");
    Console.WriteLine($"es-ES: {toSpanishSpain(s)}");
    Console.WriteLine($"en-AU: {toEnglishAustralia(s)}");
  }

  public static void Boxing()
  {
    string.Format("string of number: {0}", 256);

    // boxing.
    Console.WriteLine($"string of number: {256}");

    // avoid boxing.
    Console.WriteLine($"string of number: {256.ToString()}");
  }
}
