using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGame
{
    abstract class GameEvent
    {
        public int EventTime {get; set;}
        public abstract void ExecuteEvent();
        public GameObject GameObject { get; set; }
    }
}
