using RPS;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

internal sealed class CountdownSliderInstaller : MonoInstaller
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private TextTranslator text;

    private void Reset()
    {
        slider = GetComponentInChildren<Slider>();
        text = GetComponentInChildren<TextTranslator>();
    }

    public override void InstallBindings()
    {
        Container.BindInstance(slider);
        Container.BindInstance(text);
        Container.BindInterfacesTo<CountdownSlider>().AsSingle();
    }
}
