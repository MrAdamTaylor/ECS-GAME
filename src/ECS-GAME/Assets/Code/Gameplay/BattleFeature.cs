using Code.Common.Destruct.Systems;
using Code.Gameplay.Features.DamageApplication;
using Code.Gameplay.Features.Enemies.Systems;
using Code.Gameplay.Features.Hero.Systems;
using Code.Gameplay.Features.Lifetime.Systems;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Input.Systems;
using Code.Gameplay.TargetCollection;
using Code.Gameplay.TargetCollection.Systems;
using Code.Infrastructure.Systems;
using Code.Infrastructure.View;

namespace Code.Gameplay
{
    public class BattleFeature : Feature
    {
        public BattleFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<MovementFeature>());
            Add(systemFactory.Create<InputFeature>());
            Add(systemFactory.Create<BindViewFeature>());
            
            Add(systemFactory.Create<HeroFeature>());
            Add(systemFactory.Create<EnemyFeature>());
            Add(systemFactory.Create<DeathFeature>());
            
            Add(systemFactory.Create<CollectTargetsFeature>());
            Add(systemFactory.Create<DamageApplicationFeature>());
            Add(systemFactory.Create<ProcessDestructedFeature>());
            
        }
    }
}