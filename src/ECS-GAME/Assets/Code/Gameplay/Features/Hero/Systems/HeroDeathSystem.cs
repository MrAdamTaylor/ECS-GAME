using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class HeroDeathSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;

        public HeroDeathSystem(GameContext context)
        {
            _heroes = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.Hero, 
                GameMatcher.Dead, 
                GameMatcher.HeroAnimator,
                GameMatcher.ProcessingDeath));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            {
                hero.isMovementAvailable = false;
                hero.HeroAnimator.PlayDied();
            }
        }
    }
}