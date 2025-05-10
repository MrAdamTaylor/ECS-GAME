using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
    public class DirectionalDeltaMoveSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _movers;

        public DirectionalDeltaMoveSystem(GameContext gameContext, ITimeService timeService)
        {
            _timeService = timeService;
            _movers = gameContext.GetGroup(GameMatcher.AllOf(
                GameMatcher.WorldPosition,
                GameMatcher.Speed,
                GameMatcher.Direction,
                GameMatcher.Moving
            ));
        }

        public void Execute()
        {
            for (int i = 0; i < _movers.count; i++)
            {
                var mover = _movers.GetEntities()[i];
                mover.ReplaceWorldPosition((Vector2)mover.WorldPosition + mover.Direction * mover.Speed * _timeService.DeltaTime);
            }
        }
    }
}