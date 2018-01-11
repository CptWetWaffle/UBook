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
   public class DurationDecorator:DecoratorServiceType
    {
        public DurationDecorator(IServiceType aServiceType):base(aServiceType)
        {

            //base.Name = "Duration";

            IServiceProperty props = new ServiceProperty { Name = "initialdate", Type = "datetime", ServiceType = this };
            base.ServiceProperties.Add("initialdate", props);
            props = new ServiceProperty { Name = "enddate", Type = "datetime", ServiceType = this };
            base.ServiceProperties.Add("enddate", props);

        }

        public override bool CheckAvailability(IMemento aParam, IService aService)
        {
            var aux = aParam.GetById(aService.Id);
            var initialDate =Convert.ToDateTime(aux.Get("initialdate"));
            var endDate = Convert.ToDateTime(aux.Get("enddate"));
            var qt = 0;
            var ans = true;
            for (var i = 0; i < Convert.ToInt32((endDate - initialDate).Days); i++)
            {
                foreach (var serv in DataHolder.GetInstance().Reservations.Where(date => date.Id == aService.Id))
                {
                    var ini = new DateTime();
                    foreach (var start in serv.ServiceValues.Where(start => start.Property.Name == "initialdate"))
                    {
                        ini = Convert.ToDateTime(start.Value);
                    }

                    var end = new DateTime();
                    foreach (var endo in serv.ServiceValues.Where(endo => endo.Property.Name == "initialdate"))
                    {
                        end = Convert.ToDateTime(endo.Value);
                    }

                    if (ini.DayOfYear <= initialDate.DayOfYear && initialDate.DayOfYear <= end.DayOfYear)
                        foreach (var ar in serv.ServiceValues.Where(ar => ar.Property.Name == "quantity"))
                        {
                            qt += Convert.ToInt32(ar.Value);
                        }
                }
                aParam = new Memento(aParam);
                aParam.Add("qt", qt.ToString());
                ans = ans && _darthVader.CheckAvailability(aParam, aService);
                if (!ans)
                    break;
                initialDate.Date.AddDays(1);
            }
            return ans;
        }
    }
}
