using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Event
{
    class AddEditCustomerEvent: PubSubEvent<AddEditCustomerEventArgs>
    {
    }

    public class AddEditCustomerEventArgs
    {
        public int? Id { get; set; }
    }
}
