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

        /*private void Awake()
        {
            _entity = CreateEntity.Empty()
                .AddTransform(transform)
                .AddWorldPosition(transform.position)
                .AddDirection(Vector2.zero)
                .AddSpeed(Speed)
                .AddEnemyAnimator(EnemyAnimator)
                .AddSpriteRenderer(EnemyAnimator.SpriteRenderer)
                .AddTarget(PlayerTransform)
                .With(x => x.isHero = true)
                .With(x => x.isEnemy = true);
        }*/
    }
}