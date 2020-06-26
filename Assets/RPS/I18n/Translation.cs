using NGettext;
using System.Globalization;

namespace UGettext
{
    public class Translation
    {
        private const string LocalePath = "Locale/";

        private string localeDomain = "messages_mo";

        public Translation()
        {
        }

        public Catalog Catalog { get; private set; }

        public void LoadLocale(string localeName) =>
            Catalog = new UnityCatalog(
                localeDomain,
                LocalePath,
                new CultureInfo(localeName));

        public void SetLocaleDomain(string localeDomain) =>
                    this.localeDomain = localeDomain;
    }
}