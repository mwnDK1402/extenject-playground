using UGettext;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace RPS
{
    internal sealed class CountdownSlider : MonoBehaviour
    {
        private const string CountdownTimeKey = "CountdownTime";

        private ChoiceState choiceSettings;
        private I18n i18n;
        private string originalText;
        private Slider slider;
        private TextTranslator text;

        public float CountdownTime => slider.value;

        [Inject]
        private void Construct(
            I18n i18n,
            Slider slider,
            TextTranslator text,
            ChoiceState choiceSettings)
        {
            this.i18n = i18n;
            this.slider = slider;
            this.text = text;
            this.choiceSettings = choiceSettings;
            originalText = text.GetOriginalText();
        }

        private void OnDestroy()
        {
            slider.onValueChanged.RemoveListener(OnValueChanged);

            PlayerPrefs.SetFloat(
                CountdownTimeKey,
                slider.value);
        }

        private void OnValueChanged(float value)
        {
            choiceSettings.CountdownTime = value;
            UpdateText();
        }

        private void Reset()
        {
            slider.minValue = 1;
            slider.maxValue = 20;
            slider.value = 3;
            slider.wholeNumbers = true;
        }

        private void Start()
        {
            slider.value = PlayerPrefs.GetFloat(
                CountdownTimeKey,
                slider.value);

            UpdateText();
            choiceSettings.CountdownTime = slider.value;
            slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void UpdateText()
        {
            text.SetOriginalText(originalText, slider.value);
        }
    }
}