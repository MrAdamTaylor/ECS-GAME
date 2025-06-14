using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.TargetCollection
{
    [Game] public class TargetsBuffer : IComponent { public List<int> Values;}
    [Game] public class ReadyToCollectTargets : IComponent { }

    [Game] public class CollectTargetInterval : IComponent { public float Value;}

    [Game] public class CollectTargetsTimer : IComponent { public float Value; }

    [Game] public class LayerMask : IComponent { public int Value; }
}