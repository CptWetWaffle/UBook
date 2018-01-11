using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServicePrototype;
using UBook.Data;
using UBook.Interfaces;

namespace UBook.Behavior
{
    public class TimeDurationDecorator:DecoratorServiceType
    {
        public TimeDurationDecorator(IServiceType aServiceType) : base(aServiceType)
        {

            //base.Name = "TimeDuration";

            IServiceProperty props = new ServiceProperty { Name = "initialtime", Type = "datetime", ServiceType = this };
            base.ServiceProperties.Add("initialtime", props);
            props = new ServiceProperty { Name = "endtime", Type = "datetime", ServiceType = this };
            base.ServiceProperties.Add("endtime", props);
            props = new ServiceProperty { Name = "date", Type = "datetime", ServiceType = this };
            base.ServiceProperties.Add("date", props);

        }


        public override bool CheckAvailability(IMemento aParam, IService aService)
        {
            var aux = aParam.GetById(aService.Id);
            var initialTime = aux.Get("initialtime");
            var date = aux.Get("date");
            var iTime = "";
            var eTime = "";
            var qt = 0;
            foreach (var serv in DataHolder.GetInstance().Services.Where(serv=>serv.Id==aService.Id))
            {
                foreach (var times in serv.ServiceValues.Where(times=>times.Property.Name=="initialtime"))
                {
                    iTime = times.Value;
                }
                foreach (var times in serv.ServiceValues.Where(times => times.Property.Name == "endtime"))
                {
                    eTime = times.Value;
                }

            }
            if (Convert.ToDateTime(iTime) < Convert.ToDateTime(initialTime) && Convert.ToDateTime(initialTime) > Convert.ToDateTime(eTime))
                return false;
            foreach (var serv in DataHolder.GetInstance().Reservations.Where(serv => serv.Id == aService.Id))
            {
                foreach (var times in serv.ServiceValues.Where(times => times.Property.Name == "date"))
                {
                    if (date.Split(' ')[0] == times.Value.Split(' ')[0])
                        foreach (var ar in serv.ServiceValues.Where(ar=>ar.Property.Name=="quantity"))
                        {
                            qt += Convert.ToInt32(ar.Value);
                        }
                }
            }
            aParam = new Memento(aParam);
            aParam.Add("qt", qt.ToString());
            return _darthVader.CheckAvailability(aParam, aService);
        }
    }
}
