using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Event
{
    class ShowMyCarsEvent : PubSubEvent<ShowMyCarsEventArgs>
    {
    }

    public class ShowMyCarsEventArgs
    {
        public int Id { get; set; }
    }
}
