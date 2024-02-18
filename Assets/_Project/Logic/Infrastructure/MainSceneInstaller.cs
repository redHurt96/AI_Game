using Zenject;

namespace _Project.Infrastructure
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SystemsHandler>().AsSingle();
            Container.BindInterfacesAndSelfTo<EntryPoint>().AsSingle().NonLazy();
        }
    }
}