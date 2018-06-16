using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Event
{
    class OpenCheckoutEvent : PubSubEvent<OpenCheckoutEventArgs>
    {
    }

    public class OpenCheckoutEventArgs
    {
        public int Id { get; set; }
    }
}
