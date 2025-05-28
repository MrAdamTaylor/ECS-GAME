using Code.Gameplay.Features.Hero.Behaviours;
using Code.Infrastructure.View.EntityRegistrar;

namespace Code.Gameplay.Features.Hero
{
    public class HeroAnimatorRegistrar : EntityComponentRegistrar
    {
        public HeroAnimator HeroAnimatorComponent;
        
        public override void RegisterComponents()
        {
            Entity.AddHeroAnimator(HeroAnimatorComponent);
        }

        public override void UnregisterComponents()
        {
            Entity.RemoveHeroAnimator();
        }
    }
}