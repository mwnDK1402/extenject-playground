using System.Globalization;

namespace UGettext
{
    public static class CultureInfoExtensions
    {
        // HACK: NativeName writes "Chinese (Traditional)" in Simplified Chinese
        public static string GetFixedNativeName(this CultureInfo culture)
        {
            switch (culture.Name)
            {
                case "zh-TW":
                    return "中文 (台灣)";

                default:
                    return culture.NativeName;
            }
        }
    }
}