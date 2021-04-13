using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestGame
{
    class ReloadGunEvent: GameEvent
    {
        public override void ExecuteEvent()
        {
            Gun gun = (Gun)GameObject;
            gun.Loaded = true;
        }
    }
}
