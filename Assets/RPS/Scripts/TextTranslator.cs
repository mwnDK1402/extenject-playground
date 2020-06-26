using TMPro;
using UGettext;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TextMeshProUGUI))]
public sealed class TextTranslator : MonoBehaviour
{
    private Translation l18n;
    private TextMeshProUGUI text;

    [Inject]
    private void Construct(Translation l18n)
    {
        this.l18n = l18n;
    }

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = l18n.Catalog.GetString(text.text);
    }
}