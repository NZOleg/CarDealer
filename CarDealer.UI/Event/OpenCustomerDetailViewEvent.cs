using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Event
{
    class OpenCustomerDetailViewEvent : PubSubEvent<OpenCustomerDetailViewEventArgs>
    {
    }

    public class OpenCustomerDetailViewEventArgs
    {
        public int Id { get; set; }
    }
}
