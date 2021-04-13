using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestGame
{
    class GameObject
    {
        public float Left {get; set;}
        public float Top { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public float VelocityX { get; set; }
        public float VelocityY { get; set; }

        public float RotationAngle { get; set; }
        public float RotationVelocity { get; set; }

        public Point CenterPoint
        {
            get
            {
                return new Point((int)(Left + Width / 2), (int)(Top + Height / 2));
            }
        }

        public RectangleF Bounds
        {
            get
            {
                return new RectangleF(Left, Top, Width, Height);
            }
        }

        public GameObject()
        {
            World.Instance.AddObject(this);
        }

        public void Accelerate(float acceleration)
        {
            Accelerate(acceleration, RotationAngle);
        }

        public void Accelerate(float acceleration, float angle)
        {
            VelocityX += (float)(acceleration * Math.Cos(DegreeToRadians(angle - 90)));
            VelocityY += (float)(acceleration * Math.Sin(DegreeToRadians(angle - 90)));
        }

        private double DegreeToRadians(float angle)
        {
            return angle * 2 * Math.PI / 360;
        }

        public World World { get; set; }

        internal virtual void Paint(Graphics graphics)
        {            
        }

        public virtual void Destroy()
        {
            World.RemoveObject(this);
        }

        internal virtual void DoTime()
        {
            Left += VelocityX;
            Top += VelocityY;

            RotationAngle += RotationVelocity;
            RotationAngle = RotationAngle % 360;

            WrapObjectWhenOutsideWorld();
        }

        private void WrapObjectWhenOutsideWorld()
        {
            if (Left + Width < 0)
            {
                Left = World.Width;
            }

            if (Left > World.Width)
            {
                Left = -Width;
            }

            if (Top + Height < 0)
            {
                Top = World.Height;
            }

            if (Top > World.Height)
            {
                Top = -Height;
            }
        }
    }
}
