using NGettext;
using System;
using System.Globalization;
using UnityEngine;

namespace UGettext
{
    public class I18n
    {
        public const string LocalePath = "Locale";
        private const string DefaultLanguage = "en-US";
        private const string LanguageKey = "Language";
        private Catalog catalog;
        private string localeDomain = "messages_mo";

        public I18n()
        {
            LoadLocale(SavedLocaleName);
        }

        public event Action<Catalog> LanguageChanged;

        public Catalog Catalog
        {
            get => catalog;

            set
            {
                catalog = value;
                LanguageChanged?.Invoke(value);
                SavedLocaleName = value.CultureInfo.Name;
            }
        }

        private string SavedLocaleName
        {
            get => PlayerPrefs.GetString(LanguageKey, DefaultLanguage);
            set => PlayerPrefs.SetString(LanguageKey, value);
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