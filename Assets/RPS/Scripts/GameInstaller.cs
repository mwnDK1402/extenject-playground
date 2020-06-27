using UGettext;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<I18n>().AsSingle();
    }
}