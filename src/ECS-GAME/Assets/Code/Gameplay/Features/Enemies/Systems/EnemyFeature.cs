using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemyFeature : Feature
    {
        public EnemyFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<InitializeSpawnTimerSystem>());

            Add(systemFactory.Create<EnemySpawnSystem>());
            
            Add(systemFactory.Create<EnemyChaseHeroSystem>());
            Add(systemFactory.Create<EnemyDeathSystem>());

            Add(systemFactory.Create<FinalizeEnemyDeathProcessingSystem>());
        }
    }
}