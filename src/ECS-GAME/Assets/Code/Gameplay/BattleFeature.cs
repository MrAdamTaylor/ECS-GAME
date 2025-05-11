using Code.Common.Destruct.Systems;
using Code.Gameplay.Features.Enemies.Systems;
using Code.Gameplay.Features.Hero.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Input.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MovementFeature>());
            Add(systemFactory.Create<HeroFeature>());
            Add(systemFactory.Create<InputFeature>());
            Add(systemFactory.Create<EnemyFeature>());
            Add(systemFactory.Create<ProcessDestructedFeature>());
        }
    }
}