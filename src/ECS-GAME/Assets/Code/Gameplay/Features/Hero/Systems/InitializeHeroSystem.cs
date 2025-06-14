using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Levels;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class InitializeHeroSystem : IInitializeSystem
    {
        private ILevelDataProvider _levelDataProvider;
        private IHeroFactory _heroFactory;

        public InitializeHeroSystem(IHeroFactory heroFactory, ILevelDataProvider levelDataProvider)
        {
            _heroFactory = heroFactory;
            _levelDataProvider = levelDataProvider;
        }

        public void Initialize()
        {
            _heroFactory.CreateHero(_levelDataProvider.StartPoint);
        }
    }
}