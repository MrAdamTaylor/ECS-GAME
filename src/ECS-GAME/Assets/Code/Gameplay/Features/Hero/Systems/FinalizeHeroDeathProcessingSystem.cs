using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class FinalizeHeroDeathProcessingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private List<GameEntity> _buffer = new(1);

        public FinalizeHeroDeathProcessingSystem(GameContext context)
        {
            _enemies = context.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero, 
                    GameMatcher.Dead, 
                    GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _enemies.GetEntities(_buffer))
            {
                hero.isProcessingDeath = false;
            }
        }
    }
}