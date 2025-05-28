using Code.Infrastructure.View.EntityRegistrar;
using UnityEngine;

namespace Code.Gameplay.Common.Registrars
{
    public class SpriteRendererRegistrar : EntityComponentRegistrar
    {
        public SpriteRenderer SpriteRendererComponent;
        
        public override void RegisterComponents()
        {
            Entity.AddSpriteRenderer(SpriteRendererComponent);
        }

        public override void UnregisterComponents()
        {
            Entity.RemoveSpriteRenderer();
        }
    }
}