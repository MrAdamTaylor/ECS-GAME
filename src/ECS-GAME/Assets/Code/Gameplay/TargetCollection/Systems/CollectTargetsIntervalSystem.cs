using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.TargetCollection.Systems
{
    public class CollectTargetsIntervalSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IGroup<GameEntity> _entities;

        public CollectTargetsIntervalSystem(GameContext context, ITimeService time)
        {
            _time = time;
            _entities = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetsBuffer,
                GameMatcher.CollectTargetInterval,
                GameMatcher.CollectTargetsTimer));

        }
        
        public void Execute()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.ReplaceCollectTargetsTimer(entity.CollectTargetsTimer - _time.DeltaTime);

                if (entity.CollectTargetsTimer <= 0)
                {
                    entity.isReadyToCollectTargets = true;
                    entity.ReplaceCollectTargetsTimer(entity.CollectTargetInterval);
                }
            }
        }
    }
}