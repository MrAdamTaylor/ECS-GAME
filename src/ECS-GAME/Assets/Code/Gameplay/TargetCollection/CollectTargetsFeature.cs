using Code.Gameplay.TargetCollection.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.TargetCollection
{
    public class CollectTargetsFeature : Feature
    {
        public CollectTargetsFeature(ISystemFactory systems)
        {
            Add(systems.Create<CastForTargetsSystem>());
            Add(systems.Create<CollectTargetsIntervalSystem>());
            Add(systems.Create<CleanupTargetBuffersSystem>());
        }
    }
}