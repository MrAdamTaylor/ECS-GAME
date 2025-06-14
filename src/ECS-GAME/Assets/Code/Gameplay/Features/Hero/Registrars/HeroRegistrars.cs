using Code.Common.Extensions;
using Code.Infrastructure.View.EntityRegistrar;
using UnityEngine;

namespace Code.Gameplay.Features.Hero
{
    public class HeroRegistrars : EntityComponentRegistrar
    {
        public float MaxHP = 100;
        public float Speed = 2;
        
        private GameEntity _entity;

        public override void RegisterComponents()
        {
            Entity.AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(Speed)
                .AddCurrentHP(MaxHP)
                .AddMaxHP(MaxHP)
                .With(x => x.isHero = true)
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isTurnedAlongDirection = true);
        }

        public override void UnregisterComponents()
        {
        }
    }
}