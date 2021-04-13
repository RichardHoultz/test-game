using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TestGame
{
    public class InputController
    {        
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Windows.Forms.Keys key); 

        public static bool IsKeyPressed(Keys key)
        {
            if ((GetAsyncKeyState(key) & 0x8000) > 0)
            {
                return true;
            }

            return false;
        }
    }
}
