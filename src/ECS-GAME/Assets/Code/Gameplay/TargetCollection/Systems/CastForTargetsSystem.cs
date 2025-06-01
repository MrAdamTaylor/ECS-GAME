using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Physics;
using Entitas;

namespace Code.Gameplay.TargetCollection.Systems
{
    public class CastForTargetsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _ready;
        private readonly IPhysicsService _physicsService;
        private readonly List<GameEntity> _buffer = new(64);

        public CastForTargetsSystem(GameContext context, IPhysicsService physicsService)
        {
            _physicsService = physicsService;
            _ready = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.ReadyToCollectTargets,
                GameMatcher.TargetsBuffer,
                GameMatcher.WorldPosition,
                GameMatcher.Radius, 
                GameMatcher.LayerMask));
        }
        
        public void Execute()
        {
            foreach (var entity in _ready.GetEntities(_buffer))
            {
                entity.targetsBuffer.Values.AddRange(TargetsInRadius(entity));
                entity.isReadyToCollectTargets = false;
            }
        }

        private IEnumerable<int> TargetsInRadius(GameEntity entity)
        {
            return _physicsService
                .CircleCast(entity.WorldPosition, entity.Radius, entity.LayerMask)
                .Select(x => x.Id);
        }
    }
}