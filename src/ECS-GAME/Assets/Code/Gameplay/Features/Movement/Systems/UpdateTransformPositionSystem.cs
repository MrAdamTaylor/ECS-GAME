using Entitas;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class UpdateTransformPositionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movers;

        public UpdateTransformPositionSystem(GameContext gameContext)
        {
            _movers = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.WorldPosition,
                GameMatcher.Transform));
        }

        public void Execute()
        {
            for (int i = 0; i < _movers.count; i++)
            {
                GameEntity mover = _movers.GetEntities()[i];
                mover.Transform.position = mover.WorldPosition;
            }
        }
    }
}