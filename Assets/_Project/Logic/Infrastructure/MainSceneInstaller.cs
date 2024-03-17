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
            Container.Bind<NpcFactory>().AsSingle();
            Container.Bind<FoodsRepository>().AsSingle();
            Container.Bind<FoodFactory>().AsSingle();
            Container.Bind<Repository<Actor<Character>>>().AsSingle();
            //Container.BindInterfacesAndSelfTo<FoodSpawner>().AsSingle();
            // Container.BindInterfacesAndSelfTo<ManualFoodSpawner>().AsSingle();
            Container.BindInterfacesAndSelfTo<EntryPoint>().AsSingle().NonLazy();
        }
    }
}