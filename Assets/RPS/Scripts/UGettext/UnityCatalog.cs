using NGettext;
using System.Globalization;

namespace UGettext
{
    internal sealed class UnityCatalog : Catalog
    {
        /// <inheritdoc />
        public UnityCatalog(string domain, string localeDir)
            : base(new UnityMoLoader(domain, localeDir))
        {
        }

        /// <inheritdoc />
        public UnityCatalog(string domain, string localeDir, CultureInfo cultureInfo)
            : base(new UnityMoLoader(domain, localeDir), cultureInfo)
        {
        }
    }
}