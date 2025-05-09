using Code.Gameplay.Input.Service;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input.Systems
{
    public class EmitInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;
        private readonly IGroup<GameEntity> _inputs;

        public EmitInputSystem(GameContext gameContext, IInputService inputService)
        {
            _inputService = inputService;
            _inputs = gameContext.GetGroup(GameMatcher.Input);
        }

        public void Execute()
        {
            for (int i = 0; i < _inputs.count; i++)
            {
                var input = _inputs.GetEntities()[i];
                if (_inputService.HasAxisInput()) 
                    input.ReplaceAxisInput(new Vector2(_inputService.GetHorizontalAxis(), _inputService.GetVerticalAxis()));
                else if(input.hasAxisInput)
                    input.RemoveAxisInput();
            }
        }
    }
}