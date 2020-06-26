using UGettext;
using Zenject;

public class I18nInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var i18n = new Translation();
        i18n.LoadLocale("zh-TW");

        Container.BindInstance(i18n);
    }
}