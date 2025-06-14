using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemyChaseHeroSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _heroes;

        public EnemyChaseHeroSystem(GameContext gameContext)
        {
            _enemies = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Enemy, 
                GameMatcher.WorldPosition));
            
            _heroes = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero, 
                GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            for (int i = 0; i < _heroes.count; i++)
            {
                var hero = _heroes.GetEntities()[i];
                for (int j = 0; j < _enemies.count; j++)
                {
                    var enemy = _enemies.GetEntities()[j];
                    enemy.ReplaceDirection((hero.WorldPosition - enemy.WorldPosition).normalized);
                    enemy.isMoving = true;
                }
            }
        }
    }
}