using NGettext;
using System;
using UGettext;
using UnityEngine;
using Zenject;

namespace RPS
{
    internal sealed class LanguagePersistence : IInitializable, IDisposable
    {
        private const string DefaultLanguage = "en-US";
        private const string LanguageKey = "Language";
        private readonly I18n i18n;

        public LanguagePersistence(I18n i18n)
        {
            this.i18n = i18n;
            i18n.LoadLocale(SavedLanguage);
        }

        public string SavedLanguage
        {
            get => PlayerPrefs.GetString(LanguageKey, DefaultLanguage);
            set => PlayerPrefs.SetString(LanguageKey, value);
        }

        public void Dispose()
        {
            i18n.LanguageChanged -= OnLanguageChanged;
        }

        public void Initialize()
        {
            i18n.LanguageChanged += OnLanguageChanged;
        }

        private void OnLanguageChanged(Catalog catalog)
        {
            SavedLanguage = catalog.CultureInfo.Name;
        }
    }
}