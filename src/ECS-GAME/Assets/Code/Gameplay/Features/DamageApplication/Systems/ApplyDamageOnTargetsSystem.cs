using System;
using Entitas;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
    public class ApplyDamageOnTargetsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _damageDealer;
        private readonly GameContext _context;

        public ApplyDamageOnTargetsSystem(GameContext context)
        {
            _context = context;
            _damageDealer = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.TargetsBuffer,
                GameMatcher.Damage));
        }
        public void Execute()
        {
            foreach (GameEntity entity in _damageDealer)
            foreach (int targetId in entity.targetsBuffer.Values)
            {
                GameEntity entityWithId = _context.GetEntityWithId(targetId);
            }
        }
    }
}