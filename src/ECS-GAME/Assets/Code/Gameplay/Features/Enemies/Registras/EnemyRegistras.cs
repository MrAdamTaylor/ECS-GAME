using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Enemies.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registras
{
    public class EnemyRegistras : MonoBehaviour
    {
        public float Speed = 2;
        public EnemyAnimator EnemyAnimator;
        public Transform PlayerTransform;
        
        private GameEntity _entity;

        private void Awake()
        {
            _entity = CreateEntity.Empty()
                .AddEnemyTypeId(EnemyTypeId.Goblin)
                .AddTransform(transform)
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(Speed)
                .AddEnemyAnimator(EnemyAnimator)
                .With(x => x.isTurnedAlongDirection = true)
                .With(x => x.isEnemy = true);
        }
    }
}