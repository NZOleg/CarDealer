using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Event
{
    class AfterLoginSuccessedEvent: PubSubEvent<AfterLoginSuccessedArgs>
    {
    }
    public class AfterLoginSuccessedEventArgs
    {
        public int Id { get; set; }
        public string Role { get; set; }
    }
}
