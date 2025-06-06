using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.View.EntityRegistrar;

namespace Code.Gameplay.Features.Hero
{
    public class HeroAnimatorRegistrar : EntityComponentRegistrar
    {
        public HeroAnimator HeroAnimatorComponent;
        
        public override void RegisterComponents()
        {
            Entity
                .AddHeroAnimator(HeroAnimatorComponent)
                .AddDamageTakenAnimator(HeroAnimatorComponent);
        }

        public override void UnregisterComponents()
        {
            if(Entity.hasHeroAnimator)
                Entity.RemoveHeroAnimator();
            
            if(Entity.hasDamageTakenAnimator)
                Entity.RemoveDamageTakenAnimator();
        }
    }
}