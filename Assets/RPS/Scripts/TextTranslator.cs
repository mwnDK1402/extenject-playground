using NGettext;
using TMPro;
using UGettext;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public sealed class TextTranslator : MonoBehaviour
{
    private I18n l18n;
    private string originalText;
    private TextMeshProUGUI text;

    [Inject]
    private void Construct(I18n l18n)
    {
        this.l18n = l18n;
    }

    private void OnDestroy()
    {
        l18n.LanguageChanged -= OnLanguageChanged;
    }

    private void OnLanguageChanged(Catalog catalog)
    {
        UpdateText();
    }

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        originalText = text.text;
        UpdateText();
        l18n.LanguageChanged += OnLanguageChanged;
    }

    private void UpdateText()
    {
        text.text = l18n.Catalog.GetString(originalText);
    }
}