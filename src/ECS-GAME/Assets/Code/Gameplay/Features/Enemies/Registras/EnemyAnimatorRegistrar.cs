using Code.Gameplay.Features.Enemies.Behaviours;
using Code.Infrastructure.View.EntityRegistrar;

namespace Code.Gameplay.Features.Enemies.Registras
{
    public class EnemyAnimatorRegistrar : EntityComponentRegistrar
    {
        public EnemyAnimator EnemyAnimator;
        
        public override void RegisterComponents()
        {
            Entity.AddEnemyAnimator(EnemyAnimator);
            Entity.AddDamageTakenAnimator(EnemyAnimator);
        }

        public override void UnregisterComponents()
        {
            if(Entity.hasEnemyAnimator)
                Entity.RemoveEnemyAnimator();
            
            if(Entity.hasDamageTakenAnimator)
                Entity.RemoveDamageTakenAnimator();
        }
    }
}