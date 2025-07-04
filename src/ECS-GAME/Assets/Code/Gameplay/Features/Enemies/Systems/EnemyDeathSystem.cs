using Code.Gameplay.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemyDeathSystem: IExecuteSystem
    {
        private const float DEATH_ANIMATION_TIME = 2;
        private readonly IGroup<GameEntity> _enemies;

        public EnemyDeathSystem(GameContext game)
        {
            _enemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy, 
                    GameMatcher.Dead, 
                    GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach (GameEntity enemy in _enemies)
            {
                enemy.isMovementAvailable = false;
                enemy.isTurnedAlongDirection = false;
                enemy.RemoveTargetCollectionComponents();
                
                if(enemy.hasEnemyAnimator)
                    enemy.EnemyAnimator.PlayDied();


                enemy.ReplaceSelfDestructTimer(DEATH_ANIMATION_TIME);
            }
        }
    }
}