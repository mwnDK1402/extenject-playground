using NGettext;
using TMPro;
using UGettext;
using UnityEngine;
using Zenject;

namespace RPS
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    internal sealed class TextTranslator : MonoBehaviour
    {
        private I18n i18n;
        private string originalText;
        private TextMeshProUGUI text;
        private object[] arguments;

        public string GetOriginalText() => originalText;

        public void SetOriginalText(string originalText, params object[] args)
        {
            this.originalText = originalText;
            arguments = args;
            UpdateText();
        }

        [Inject]
        private void Construct(I18n i18n)
        {
            this.i18n = i18n;
            text = GetComponent<TextMeshProUGUI>();
            originalText = text.text;
            arguments = new object[0];
        }

        private void OnDestroy()
        {
            i18n.LanguageChanged -= OnLanguageChanged;
        }

        private void OnLanguageChanged(Catalog catalog)
        {
            UpdateText();
        }

        private void Start()
        {
            UpdateText();
            i18n.LanguageChanged += OnLanguageChanged;
        }

        private void UpdateText()
        {
            text.text = i18n.Catalog.GetString(originalText, arguments);
        }
    }
}