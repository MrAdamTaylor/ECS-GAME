using Code.Gameplay.Common.Collisions;
using Code.Infrastructure.View.EntityRegistrar;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View
{
    public class EntityBehaviour : MonoBehaviour, IEntityView
    {
        public GameEntity Entity => _entity;
        
        public GameObject GameObject => gameObject;

        private GameEntity _entity;
        private ICollisionRegistry _collisionRegistry;

        [Inject]
        private void Construct(ICollisionRegistry collisionRegistry)
        {
            _collisionRegistry = collisionRegistry;
        }

        public void SetEntity(GameEntity entity)
        {
            _entity = entity; 
            _entity.AddView(this);
            entity.Retain(this);

            RegistrationComponents();

            
        }

        public void ReleaseEntity()
        {
            UnRegistrationComponents();
            
            _entity.Release(this);
            _entity = null;
        }

        private void RegistrationComponents()
        {
            for (int i = 0; i < GetComponentsInChildren<IEntityComponentRegistrar>().Length; i++)
            {
                var registrar = GetComponentsInChildren<IEntityComponentRegistrar>()[i];
                registrar.RegisterComponents();
            }
            
            foreach (var collider in GetComponentsInChildren<Collider2D>(includeInactive: true))
            {
                _collisionRegistry.Register(collider.GetInstanceID(), _entity);
            }
        }
        
        private void UnRegistrationComponents()
        {
            for (int i = 0; i < GetComponentsInChildren<IEntityComponentRegistrar>().Length; i++)
            {
                var registrar = GetComponentsInChildren<IEntityComponentRegistrar>()[i];
                registrar.UnregisterComponents();
            }
            
            foreach (var collider in GetComponentsInChildren<Collider2D>(includeInactive: true))
            {
                _collisionRegistry.Unregister(collider.GetInstanceID());
            }
        }
    }
}