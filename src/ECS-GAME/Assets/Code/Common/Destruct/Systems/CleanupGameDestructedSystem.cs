using System.Collections.Generic;
using Entitas;

namespace Code.Common.Destruct.Systems
{
    public class CleanupGameDestructedSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new (64);

        public CleanupGameDestructedSystem(GameContext game) => 
            _entities = game.GetGroup(GameMatcher.Destructed);

        public void Cleanup()
        {
            var entities = _entities.GetEntities(_buffer);
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].Destroy();
            }
        }
    }
}