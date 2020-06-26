using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UGettext;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(TMP_Dropdown))]
public sealed class LanguageSelector : MonoBehaviour
{
    [SerializeField]
    private SupportedLanguages supported;

    [HideInInspector, SerializeField]
    private TMP_Dropdown dropdown;

    private I18n i18n;

    [Inject]
    public void Construct(I18n i18n)
    {
        this.i18n = i18n;
    }

    public void OnLanguageSelected(int index)
    {
        i18n.LoadLocale(new CultureInfo(supported.IDs[index]));
    }

#if UNITY_EDITOR

    private void Reset()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        UnityEditor.Events.UnityEventTools.RemovePersistentListener<int>(
            dropdown.onValueChanged,
            OnLanguageSelected);
        UnityEditor.Events.UnityEventTools.AddPersistentListener(
            dropdown.onValueChanged,
            OnLanguageSelected);

        dropdown.ClearOptions();

        var options = new List<TMP_Dropdown.OptionData>();
        foreach (var id in supported.IDs)
        {
            var culture = new CultureInfo(id);
            var option = new TMP_Dropdown.OptionData(culture.NativeName);
            options.Add(option);
        }

        dropdown.AddOptions(options);
    }

#endif
}