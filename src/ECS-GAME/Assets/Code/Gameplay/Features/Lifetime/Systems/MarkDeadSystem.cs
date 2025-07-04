using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Lifetime.Systems
{
    public class MarkDeadSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private List<GameEntity> _buffer = new(128);

        public MarkDeadSystem(GameContext contextParam)
        {
            _entities = contextParam.GetGroup(GameMatcher
                .AllOf(GameMatcher.CurrentHP, GameMatcher.MaxHP)
                .NoneOf(GameMatcher.Dead));
        }

        public void Execute()
        {
            foreach (var entity in _entities.GetEntities(_buffer))
            {
                if (entity.CurrentHP <= 0)
                {
                    entity.isDead = true;
                    entity.isProcessingDeath = true;
                }
            }
        }
    }
}