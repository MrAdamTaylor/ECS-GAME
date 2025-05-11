namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemyFeature : Feature
    {
        public EnemyFeature(GameContext gameContext)
        {
            Add(new ChaseHeroSystem(gameContext));
        }
    }
}