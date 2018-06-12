using CarDealer.DataAccess;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Event
{
    class AfterLoginSuccessedEvent: PubSubEvent<AfterLoginSuccessedEventArgs>
    {
    }
    public class AfterLoginSuccessedEventArgs
    {
        public string Role { get; set; }
        public Person Person { get; set; }
    }
}
