using CarDealer.DataAccess;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Event
{
    class OpenSaleDetailViewEvent : PubSubEvent<OpenSaleDetailViewEventArgs>
    {
    }

    public class OpenSaleDetailViewEventArgs
    {
        public CarSale Sale { get; set; }
    }
}
