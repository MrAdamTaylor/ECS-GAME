using Entitas;
using UnityEngine;

namespace Code.Common.Destruct.Systems
{
    public class CleanupGameDestructedViewSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;

        public CleanupGameDestructedViewSystem(GameContext game) => 
            _entities = game.GetGroup(GameMatcher.AllOf(GameMatcher.Destructed, GameMatcher.View));

        public void Cleanup()
        {
            for (int i = 0; i < _entities.count; i++)
            {
                var entity = _entities.GetEntities()[i];
                entity.View.ReleaseEntity();
                Object.Destroy(entity.View.GameObject);
            }
        }
    }
}