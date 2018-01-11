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
    public class TimeOffDecorator:DecoratorServiceType
    {
        public TimeOffDecorator(IServiceType aServiceType) : base(aServiceType)
        {
            //Name = "Time OFF";

            IServiceProperty props = new ServiceProperty { Name = "initialtimeoff", Type = "datetime", ServiceType = this };
            base.ServiceProperties.Add("initialtimeoff", props);
            props = new ServiceProperty { Name = "endtimeoff", Type = "datetime", ServiceType = this };
            base.ServiceProperties.Add("endtimeoff", props);
        }

        public override bool CheckAvailability(IMemento aParam, IService aService)
        {
            var aux = aParam.GetById(aService.Id);
            //var initialTime = aux.Get("initialtime");
            var endTime = aux.Get("date");
            var iDate = aux.Get("initialdate");
            var eDate = aux.Get("enddate");
            var i = "";
            var e = "";
            var a = 0;
            foreach (var r in DataHolder.GetInstance().Services.Where(times=>times.Id == aService.Id).SelectMany(times => times.ServiceValues.Where(r => r.Property.Name == "initialtimeoff" || r.Property.Name == "endtimeoff")))
            {
                if (r.Property.Name == "initialtimeoff")
                    i = r.Value;
                else
                    e = r.Value;
            }
            if (Convert.ToDateTime(endTime) >= Convert.ToDateTime(i) && Convert.ToDateTime(endTime) <= Convert.ToDateTime(e) || Convert.ToDateTime(iDate) >= Convert.ToDateTime(i) && Convert.ToDateTime(iDate) <= Convert.ToDateTime(e) || Convert.ToDateTime(eDate) >= Convert.ToDateTime(i) && Convert.ToDateTime(eDate) <= Convert.ToDateTime(e))
                return false;
            return _darthVader.CheckAvailability(aParam,aService);
        }
    }
}
