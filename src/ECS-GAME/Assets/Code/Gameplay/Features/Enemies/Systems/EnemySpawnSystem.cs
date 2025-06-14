using Code.Common.Extensions;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Enemies.Factory;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Systems
{
    public class EnemySpawnSystem : IExecuteSystem
    {
        private const float SPAWN_DISTANCE_GAP = 0.5f;
        
        
        private readonly IGroup<GameEntity> _timers;
        private readonly ITimeService _timeService;
        private readonly IEnemyFactory _enemyFactory;
        private readonly IGroup<GameEntity> _heroes;
        private ICameraProvider _cameraProvider;

        public EnemySpawnSystem(GameContext context, ITimeService timeService, IEnemyFactory enemyFactory, ICameraProvider cameraProvider)
        {
            _cameraProvider = cameraProvider;
            _enemyFactory = enemyFactory;
            _timeService = timeService;
            
            _timers = context.GetGroup(GameMatcher.SpawnTimer);
            _heroes = context.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Hero, 
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity hero in _heroes)
            foreach (GameEntity timer in _timers)
            {
                timer.ReplaceSpawnTimer(timer.SpawnTimer - _timeService.DeltaTime);
                if (timer.SpawnTimer <= 0)
                {
                    timer.ReplaceSpawnTimer(1);
                    _enemyFactory.CreateEnemy(EnemyTypeId.Goblin, at: RandomSpawnPosition(hero.WorldPosition));
                }
            }
        }

        private Vector3 RandomSpawnPosition(Vector3 heroWorldPosition)
        {
            bool startWithHorizontal = Random.Range(0, 2) == 0;

            return startWithHorizontal
                ? HorizontalSpawnPosition(heroWorldPosition)
                : VerticalSpawnPosition(heroWorldPosition);
        }
        
        private Vector2 HorizontalSpawnPosition(Vector2 aroundPosition)
        {
            Vector2[] horizontalDirections = { Vector2.left, Vector2.right };
            Vector2 primaryDirection = horizontalDirections.PickRandom();

            float horizontalOffsetDistance = _cameraProvider.WorldScreenWidth / 2 + SPAWN_DISTANCE_GAP;
            float verticalRandomOffset = Random.Range(-_cameraProvider.WorldScreenHeight / 2, _cameraProvider.WorldScreenHeight / 2);

            return aroundPosition + primaryDirection * horizontalOffsetDistance + Vector2.up * verticalRandomOffset;
        }

        private Vector2 VerticalSpawnPosition(Vector2 aroundPosition)
        {
            Vector2[] verticalDirections = { Vector2.up, Vector2.down };
            Vector2 primaryDirection = verticalDirections.PickRandom();

            float verticalOffsetDistance = _cameraProvider.WorldScreenHeight / 2 + SPAWN_DISTANCE_GAP;
            float horizontalRandomOffset = Random.Range(-_cameraProvider.WorldScreenWidth / 2, _cameraProvider.WorldScreenWidth / 2);

            return aroundPosition + primaryDirection * verticalOffsetDistance + Vector2.right * horizontalRandomOffset;
        }
    }
}