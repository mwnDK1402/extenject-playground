using UGettext;
using UnityEngine;
using Zenject;

namespace RPS
{
    internal sealed class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private bool deletePlayerPrefs = false;

        public override void InstallBindings()
        {
            if (deletePlayerPrefs)
                PlayerPrefs.DeleteAll();

            Container.Bind<I18n>().AsSingle();
            Container.BindInterfacesTo<LanguagePersistence>().AsSingle();
        }
    }
}