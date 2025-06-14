using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Lifetime.Systems
{
    public class DeathFeature : Feature
    {
        public DeathFeature(ISystemFactory systemsFactory)
        {
            Add(systemsFactory.Create<MarkDeadSystem>());
        }
    }
}