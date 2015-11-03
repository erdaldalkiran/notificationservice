namespace Kamrad.NotificationService.Business.Ports.Persistance
{
    public interface IRepository<T>
    {
        void Add(T aggregate);
    }
}