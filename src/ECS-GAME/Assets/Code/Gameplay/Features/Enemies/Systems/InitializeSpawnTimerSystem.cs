using Code.Common.Entity;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class InitializeSpawnTimerSystem : IInitializeSystem
    {
        private const float ENEMY_SPAWN_TIMER = 1f;
        
        public void Initialize()
        {
            CreateEntity.Empty()
                .AddSpawnTimer(ENEMY_SPAWN_TIMER);
        }
    }
}