using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGame
{
    class DestroyObjectEvent: GameEvent
    {
        public override void ExecuteEvent()
        {
            GameObject.Destroy();
        }
    }
}
