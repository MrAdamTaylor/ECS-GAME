using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
    public class MovementFeature : Feature 
    {
        public MovementFeature(ISystemFactory systemFactory)
        {
            Add(systemFactory.Create<DirectionalDeltaMoveSystem>());
            
            Add(systemFactory.Create<TurnAlongDirectionSystem>());

            Add(systemFactory.Create<UpdateTransformPositionSystem>());
        }
    }
}