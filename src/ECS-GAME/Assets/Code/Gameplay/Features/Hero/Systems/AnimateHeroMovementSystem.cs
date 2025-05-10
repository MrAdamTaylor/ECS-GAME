using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class AnimateHeroMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;

        public AnimateHeroMovementSystem(GameContext contexts)
        {
            _heroes = contexts.GetGroup(GameMatcher.AllOf(GameMatcher.Hero, GameMatcher.HeroAnimator));
        }

        public void Execute()
        {
            for (int i = 0; i < _heroes.count; i++)
            {
                GameEntity hero = _heroes.GetEntities()[i];
                if(hero.isMoving)
                    hero.HeroAnimator.PlayMove();
                else
                    hero.HeroAnimator.PlayIdle();
            }
        }
    }
}