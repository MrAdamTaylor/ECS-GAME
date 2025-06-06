namespace Code.Gameplay.TargetCollection
{
    public static class TargetCollectionEntityExtension
    {
        public static GameEntity RemoveTargetCollectionComponents(this GameEntity entity)
        {
            if(entity.hasTargetsBuffer)
                entity.RemoveTargetsBuffer();
            
            if(entity.hasCollectTargetInterval)
                entity.RemoveCollectTargetInterval();
            
            if(entity.hasCollectTargetsTimer)
                entity.RemoveCollectTargetsTimer();
            
            entity.isReadyToCollectTargets = false;
            return entity;
        }
    }
}