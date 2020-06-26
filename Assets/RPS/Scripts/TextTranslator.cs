using ngettext_unity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public sealed class TextTranslator : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        NGettextUnity.Instance.LoadLocale("zh-TW");
        Debug.Log(text.text);
        text.text = NGettextUnity.Catalog.GetString(text.text);
        Debug.Log(text.text);
    }
}
