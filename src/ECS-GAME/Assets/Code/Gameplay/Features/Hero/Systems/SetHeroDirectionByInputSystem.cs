using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
    public class SetHeroDirectionByInputSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _heroes;
        private readonly IGroup<GameEntity> _inputs;

        public SetHeroDirectionByInputSystem(GameContext contexts)
        {
            _heroes = contexts.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero, 
                    GameMatcher.MovementAvailable));
            _inputs = contexts.GetGroup(GameMatcher.Input);
        }

        public void Execute()
        {
            for (int i = 0; i < _inputs.count; i++)
            {
                GameEntity input = _inputs.GetEntities()[i];
                for (int j = 0; j < _heroes.count; j++)
                {
                    GameEntity hero = _heroes.GetEntities()[j];
                    hero.isMoving = input.hasAxisInput;
                
                    if(input.hasAxisInput)
                        hero.ReplaceDirection(input.axisInput.Value.normalized);
                }
            }
        }
    }
}