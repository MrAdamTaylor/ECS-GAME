using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Infrastructure.View.EntityRegistrar;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registras
{
    public class EnemyRegistras : EntityComponentRegistrar
    {
        public float HP = 3;
        public float Damage = 1;
        public float Speed = 2;
        
        public override void RegisterComponents()
        {
            Entity.AddEnemyTypeId(EnemyTypeId.Goblin)
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(Speed)
                .AddCurrentHP(HP)
                .AddMaxHP(HP)
                .AddDamage(Damage)
                .AddTargetsBuffer(new List<int>(1))
                .AddRadius(0.3f)
                .AddCollectTargetInterval(0.5f)
                .AddCollectTargetsTimer(0)
                .AddLayerMask(CollisionLayer.Hero.AsMask())
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isEnemy = true);
        }

        public override void UnregisterComponents()
        {
            
        }
    }
}