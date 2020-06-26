using NGettext;
using System;
using System.Globalization;

namespace UGettext
{
    public class I18n
    {
        public const string LocalePath = "Locale";

        private Catalog catalog;

        private string localeDomain = "messages_mo";

        public I18n()
        {
        }

        public event Action<Catalog> LanguageChanged;

        public Catalog Catalog
        {
            get => catalog;

            set
            {
                catalog = value;
                LanguageChanged?.Invoke(value);
            }
        }

        public void LoadLocale(string localeName) =>
            Catalog = new UnityCatalog(
                localeDomain,
                LocalePath,
                new CultureInfo(localeName));

        public void LoadLocale(CultureInfo cultureInfo) =>
            Catalog = new UnityCatalog(
                localeDomain,
                LocalePath,
                cultureInfo);

        public void SetLocaleDomain(string localeDomain) =>
                    this.localeDomain = localeDomain;
    }
}