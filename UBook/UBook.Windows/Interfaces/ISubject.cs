namespace UBook.Interfaces
{
    public interface ISubject
    {
        void Notify();

        void Subscribe(IObserver obs);

        void Unsubscribe(IObserver obs);
    }
}
