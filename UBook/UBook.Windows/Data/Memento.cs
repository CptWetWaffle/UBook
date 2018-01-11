using System.Collections.Generic;
using ServicePrototype;
using UBook.Interfaces;

namespace UBook.Data
{
    public class Memento:IMemento
    {
        private readonly IMemento _darthVader;
        private readonly Dictionary<string, string> _values;
        private readonly int _count = 1;
        public int ServiceId { get; set; }
        public IMemento GetById(int id)
        {
            if (id == ServiceId)
                return this;
            else if (_darthVader.GetById(id) != null)
                _darthVader.GetById(id);
            return null;

        }

        public int Count { get { return _count; } }

        public Memento()
        {
            _darthVader = null;
            _values = new Dictionary<string, string>();
            
        }

        public Memento(IMemento father):this()
        {
            _darthVader = father;
            if (_darthVader != null) _count = _darthVader.Count + 1;
        }

        public void Add(string key, string value)
        {
            _values.Add(key,value);
        }

        public string Get(string key)
        {
            if(_values.ContainsKey(key))
                return _values[key];
            else if (_darthVader != null &&_darthVader.Get(key) != null)
                return _darthVader.Get(key);
            return null;
        }

        public void SetDefault(string key)
        {
            _values.Add(key,"");
        }

        public void Del(string key)
        {
            if(_values.ContainsKey(key))
                _values.Remove(key);
            else if(_darthVader != null)
                _darthVader.Del(key);
        }

        
    }
}
