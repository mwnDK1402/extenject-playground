using UGettext;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var i18n = new I18n();
        i18n.LoadLocale("en-US");

        Container.BindInstance(i18n);
    }
}