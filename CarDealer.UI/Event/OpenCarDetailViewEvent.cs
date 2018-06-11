using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Event
{
    class OpenCarDetailViewEvent: PubSubEvent<OpenCarDetailViewEventArgs>
    {
    }

    public class OpenCarDetailViewEventArgs
    {
        public int Id { get; set; }
    }
}
