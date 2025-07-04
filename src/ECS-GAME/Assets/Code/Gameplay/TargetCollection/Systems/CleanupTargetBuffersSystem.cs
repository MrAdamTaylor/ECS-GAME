using Entitas;

namespace Code.Gameplay.TargetCollection.Systems
{
    public class CleanupTargetBuffersSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public CleanupTargetBuffersSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.TargetsBuffer);
        }
        
        public void Cleanup()
        {
            foreach (GameEntity entity in _entities)
            {
                entity.targetsBuffer.Values.Clear();
            }
        }
    }
}