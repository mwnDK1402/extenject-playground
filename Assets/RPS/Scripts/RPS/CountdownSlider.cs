using System;
using UGettext;
using UnityEngine.UI;
using Zenject;

namespace RPS
{
    internal sealed class CountdownSlider : IInitializable, IDisposable
    {
        private I18n i18n;
        private Slider slider;
        private TextTranslator text;
        private string originalText;

        public float CountdownTime => slider.value;

        [Inject]
        public CountdownSlider(I18n i18n, Slider slider, TextTranslator text)
        {
            this.i18n = i18n;
            this.slider = slider;
            this.text = text;
            originalText = text.GetOriginalText();
        }

        void IDisposable.Dispose()
        {
            slider.onValueChanged.RemoveListener(OnValueChanged);
        }

        void IInitializable.Initialize()
        {
            UpdateText();
            slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(float value)
        {
            UpdateText();
        }

        private void UpdateText()
        {
            text.SetOriginalText(originalText, slider.value);
        }
    }
}
