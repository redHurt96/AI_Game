using _Project.AI.Implementation;
using _Project.Game.Domain;
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
            Container.Bind<FoodsRepository>().AsSingle();
            Container.Bind<FoodSpawner>().AsSingle();
            Container.Bind<Repository<Actor<Character>>>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<EntryPoint>().AsSingle().NonLazy();
        }
    }
}