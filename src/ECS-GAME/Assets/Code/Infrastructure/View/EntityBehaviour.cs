using Code.Infrastructure.View.EntityRegistrar;
using UnityEngine;

namespace Code.Infrastructure.View
{
    public class EntityBehaviour : MonoBehaviour, IEntityView
    {
        public GameEntity Entity => _entity;
        
        public GameObject GameObject => gameObject;

        private GameEntity _entity;

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
        }
        
        private void UnRegistrationComponents()
        {
            for (int i = 0; i < GetComponentsInChildren<IEntityComponentRegistrar>().Length; i++)
            {
                var registrar = GetComponentsInChildren<IEntityComponentRegistrar>()[i];
                registrar.UnregisterComponents();
            }
        }
    }
}