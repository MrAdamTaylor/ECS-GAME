using Code.Gameplay.Features.Enemies.Behaviours;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies
{
    [Game] public class Enemy : IComponent { }
    
    [Game] public class TargetComponent : IComponent { public Transform Value; }
    
    [Game] public class EnemyAnimatorComponent : IComponent { public EnemyAnimator Value; }
}