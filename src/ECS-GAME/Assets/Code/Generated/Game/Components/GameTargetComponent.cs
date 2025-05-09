//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherTarget;

    public static Entitas.IMatcher<GameEntity> Target {
        get {
            if (_matcherTarget == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Target);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTarget = matcher;
            }

            return _matcherTarget;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Code.Gameplay.Features.Enemies.TargetComponent target { get { return (Code.Gameplay.Features.Enemies.TargetComponent)GetComponent(GameComponentsLookup.Target); } }
    public UnityEngine.Transform Target { get { return target.Value; } }
    public bool hasTarget { get { return HasComponent(GameComponentsLookup.Target); } }

    public GameEntity AddTarget(UnityEngine.Transform newValue) {
        var index = GameComponentsLookup.Target;
        var component = (Code.Gameplay.Features.Enemies.TargetComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Enemies.TargetComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceTarget(UnityEngine.Transform newValue) {
        var index = GameComponentsLookup.Target;
        var component = (Code.Gameplay.Features.Enemies.TargetComponent)CreateComponent(index, typeof(Code.Gameplay.Features.Enemies.TargetComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveTarget() {
        RemoveComponent(GameComponentsLookup.Target);
        return this;
    }
}
