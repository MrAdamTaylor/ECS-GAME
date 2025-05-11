using Code.Infrastructure.View;
using Entitas;

namespace Code.Common
{
    [Game] public class Destructed : IComponent { }
    [Game] public class View : IComponent { public IEntityView Value; }
}