﻿using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.UI.Event
{
    class OpenEmployeeListEvent : PubSubEvent<OpenEmployeeListEventArgs>
    {
    }

    internal class OpenEmployeeListEventArgs
    {
    }
}
