using UGettext;
using Zenject;

namespace RPS
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<I18n>().AsSingle();
        }
    }
}