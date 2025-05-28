using Code.Common.Extensions;
using Code.Infrastructure.View.EntityRegistrar;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registras
{
    public class EnemyRegistras : EntityComponentRegistrar
    {
        public float Speed = 2;
        
        public override void RegisterComponents()
        {
            Entity.AddEnemyTypeId(EnemyTypeId.Goblin)
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(Speed)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isEnemy = true);
        }

        public override void UnregisterComponents()
        {
            
        }
    }
}