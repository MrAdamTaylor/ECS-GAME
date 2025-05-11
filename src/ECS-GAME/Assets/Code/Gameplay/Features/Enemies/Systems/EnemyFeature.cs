using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemyFeature : Feature
    {
        public EnemyFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<ChaseHeroSystem>());
        }
    }
}