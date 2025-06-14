using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemySpawnSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _group;

        public EnemySpawnSystem(GameContext context)
        {

        }

        public void Execute()
        {
        }

    }
}