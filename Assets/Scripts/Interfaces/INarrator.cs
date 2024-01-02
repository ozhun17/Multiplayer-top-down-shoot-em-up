namespace Interfaces
{
    public interface INarrator
    {
        void AddSubscriber(ISubscriber subscriber);
        void RemoveSubscriber(ISubscriber subscriber);
        void NarrateToSubscribers(ISubscriber subscriber);
    }
}
