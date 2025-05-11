namespace Code.Infrastructure.View.EntityRegistrar
{
    public interface IEntityComponentRegistrar
    {
        void RegisterComponents();
        void UnregisterComponents();
    }
}