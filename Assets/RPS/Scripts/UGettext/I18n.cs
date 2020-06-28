using NGettext;
using System;
using System.Globalization;

namespace UGettext
{
    public sealed class I18n
    {
        public const string LocalePath = "Locale";
        private Catalog catalog;

        public I18n(string localeDomain = "messages_mo")
        {
            LocaleDomain = localeDomain;
        }

        public event Action<Catalog> LanguageChanged;

        public Catalog Catalog
        {
            get => catalog;

            private set
            {
                catalog = value;
                LanguageChanged?.Invoke(value);
            }
        }

        public string LocaleDomain { get; set; }

        public void LoadLocale(string localeName) =>
            LoadLocale(new CultureInfo(localeName));

        public void LoadLocale(CultureInfo cultureInfo) =>
            Catalog = new UnityCatalog(
                LocaleDomain,
                LocalePath,
                cultureInfo);
    }
}