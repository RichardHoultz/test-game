using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestGame
{
    class Bullet: GameObject
    {
        private Color m_BackColor;

        private Color m_FirstColor;
        private Color m_SecondColor;

        public Bullet()
        {
            m_FirstColor = Color.Gray;
            m_SecondColor = Color.White;

            Width = 3;
            Height = 3;

            World.Instance.AddEvent(new DestroyObjectEvent() { GameObject = this }, 2000);
        }

        internal override void Paint(System.Drawing.Graphics graphics)
        {
            graphics.FillRectangle(new SolidBrush(m_BackColor), Bounds);
        }

        internal override void DoTime()
        {
            base.DoTime();

            //Shift colors to "flash" bullet appearance
            if (m_BackColor == m_FirstColor)
            {
                m_BackColor = m_SecondColor;
            }
            else
            {
                m_BackColor = m_FirstColor;
            }
        }
    }
}
