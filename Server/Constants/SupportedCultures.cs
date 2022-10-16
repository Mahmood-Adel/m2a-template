using System.Globalization;

namespace Server.Constants;

public class SupportedCultures
{
    public const string LanguageArabic = "ar";

    public const string LanguageEnglish = "en";

    public const string CountryEg = "EG";

    private static CultureInfo Arabic = new ($"{LanguageArabic}-{CountryEg}");
    private static CultureInfo English = new ($"{LanguageEnglish}-{CountryEg}");

    public static CultureInfo[] All = 
    {
        Arabic,
        English
    };

    public static CultureInfo Default = Arabic;
}