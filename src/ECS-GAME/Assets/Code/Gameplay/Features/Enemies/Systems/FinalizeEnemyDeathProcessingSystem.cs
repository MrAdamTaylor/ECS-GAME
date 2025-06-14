using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class FinalizeEnemyDeathProcessingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private List<GameEntity> _buffer = new(128);

        public FinalizeEnemyDeathProcessingSystem(GameContext context)
        {
            _enemies = context.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy, 
                    GameMatcher.Dead, 
                    GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies.GetEntities(_buffer))
            {
                enemy.isProcessingDeath = false;
            }
        }
    }
}