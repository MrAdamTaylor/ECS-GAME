using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.View.Factory
{
    public class EntityViewFactory : IEntityViewFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInstantiator _instantiator;
        private readonly Vector3 _farAwayPosition = new Vector3(-999, 999, 0);

        public EntityViewFactory(IAssetProvider assetProvider, IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _assetProvider = assetProvider;
        }
        
        public EntityBehaviour CreateViewForEntity(GameEntity entity)
        {
            var viewPrefab = _assetProvider.LoadAsset<EntityBehaviour>(entity.ViewPath);
            var view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                viewPrefab, 
                position: _farAwayPosition, 
                Quaternion.identity, 
                parentTransform: null);
            
            view.SetEntity(entity);
            return view;
        }
        
        public EntityBehaviour CreateViewForEntityFromPrefab(GameEntity entity)
        {
            var view = _instantiator.InstantiatePrefabForComponent<EntityBehaviour>(
                entity.ViewPrefab, 
                position: _farAwayPosition, 
                Quaternion.identity, 
                parentTransform: null);
            
            view.SetEntity(entity);
            return view;
        }

    }
}