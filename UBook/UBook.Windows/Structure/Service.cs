using System.Collections.Generic;
using System.Linq;
using ServicePrototype;
using UBook.Creation;
using UBook.Interfaces;

namespace UBook.Structure
{
    public class Service:IService
    {
        private static int _mId = 0;
        private IList<IServiceValue> _serviceValues = new List<IServiceValue>();
        public int Id { get; private set; }
        public IServiceType Type { get; set; }
        

        public IList<IServiceValue> ServiceValues
        {
            get { return _serviceValues; }
        }

        public Service()
        {
            Id = _mId++;
        }

        public override string ToString()
        {
            var aux = Type.ToString();
            return _serviceValues.Where(serv => !serv.Property.Name.ToLower().Contains("date") && !serv.Property.Name.ToLower().Contains("time")).Aggregate(aux, (current, serv) => current + serv.ToString());
        }

        public bool CheckAvailablility(IMemento aMemento)
        {
            return Type.CheckAvailability(aMemento, this);
        }

        public string LineToString()
        {
            var aux = Type.ToString();
            return _serviceValues.Aggregate(aux, (current, serv) => current + serv.LineToString());
        }

        public void AddValues(string name, string value)
        {
            var val = Factory.GetInstance().MakeServiceValue();
            val.Property = this.Type.GetProperty(name);
            val.Value = value;
            val.Service = this;
            this.ServiceValues.Add(val);
        }

        public void Clone( IService var)
        {
            Id = var.Id;
            foreach (var v in var.ServiceValues)
            {
                var va = new ServiceValue();
                va.Clone(v);
                _serviceValues.Add(va);
            }
            
            Type = var.Type;
        }
    }

}
