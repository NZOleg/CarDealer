using CarDealer.UI.Helpers;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Event
{
    class SaleFilterHasChangedEvent : PubSubEvent<SaleFilterHasChangedEventArgs>
    {
    }

    public class SaleFilterHasChangedEventArgs
    {
        public SaleFilters SaleFilter { get; set; }
    }
}
