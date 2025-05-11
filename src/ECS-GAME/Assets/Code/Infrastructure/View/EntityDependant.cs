using UnityEngine;

namespace Code.Infrastructure.View
{
    public abstract class EntityDependant : MonoBehaviour
    {
        public EntityBehaviour EntityView;
        
        public GameEntity Entity => EntityView.Entity != null ? EntityView.Entity : null;

        private void Awake()
        {
            if(!EntityView)
                EntityView = GetComponent<EntityBehaviour>();
        }
    }
}