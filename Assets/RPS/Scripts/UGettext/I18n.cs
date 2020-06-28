using NGettext;
using System;
using System.Globalization;
using UnityEngine;

namespace UGettext
{
    public sealed class I18n
    {
        public const string LocalePath = "Locale";
        private const string DefaultLanguage = "en-US";
        private const string LanguageKey = "Language";
        private Catalog catalog;

        public I18n(string localeDomain = "messages_mo")
        {
            this.LocaleDomain = localeDomain;
            LoadLocale(SavedLocaleName);
        }

        public event Action<Catalog> LanguageChanged;

        public Catalog Catalog
        {
            get => catalog;

            private set
            {
                catalog = value;
                LanguageChanged?.Invoke(value);
                SavedLocaleName = value.CultureInfo.Name;
            }
        }

        public string LocaleDomain { get; set; }

        private string SavedLocaleName
        {
            get => PlayerPrefs.GetString(LanguageKey, DefaultLanguage);
            set => PlayerPrefs.SetString(LanguageKey, value);
        }

        public void LoadLocale(string localeName) =>
            LoadLocale(new CultureInfo(localeName));

        public void LoadLocale(CultureInfo cultureInfo) =>
            Catalog = new UnityCatalog(
                LocaleDomain,
                LocalePath,
                cultureInfo);
    }
}