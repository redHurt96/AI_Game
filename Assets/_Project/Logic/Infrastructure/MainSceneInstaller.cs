using _Project.Services;
using Zenject;

namespace _Project.Infrastructure
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SystemsHandler>().AsSingle();
            Container.Bind<NpcFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<EntryPoint>().AsSingle().NonLazy();
        }
    }
}