namespace UBook.Interfaces
{
    public interface IMemento
    {
        void Add(string key, string value);

        string Get(string key);

        void SetDefault(string key);

        void Del(string key);

        int ServiceId { get; set; }

        IMemento GetById(int id);

        int Count { get; }
    }
}
