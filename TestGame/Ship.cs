using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestGame
{
    class Ship: ImageGameObject
    {
        Gun m_Gun;

        public Ship()
        {
            Image = Resources.Ship;
            Width = Image.Width;
            Height = Image.Height;

            m_Gun = new Gun();
            m_Gun.Owner = this;            
        }

        internal override void DoTime()
        {
            HandleInput();
            base.DoTime();
        }


        private void HandleInput()
        {
            if (InputController.IsKeyPressed(Keys.Left))
            {
                RotationVelocity = -10;
            }
            else if (InputController.IsKeyPressed(Keys.Right))
            {
                RotationVelocity = 10;
            }
            else
            {
                RotationVelocity = 0;
            }

            if (InputController.IsKeyPressed(Keys.Up))
            {
                Accelerate(1);
            }

            if (InputController.IsKeyPressed(Keys.Space))
            {                
                m_Gun.RotationAngle = RotationAngle;
                m_Gun.Fire();
            }
        }       
    }
}
