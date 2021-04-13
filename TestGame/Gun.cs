using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestGame
{
    class Gun: GameObject
    {
        public bool Loaded { get; set; }

        public GameObject Owner { get; set; }
        public Point PositionInOwner { get; set; }
        public int ReloadTime { get; set; }

        public Gun()
        {
            ReloadTime = 500;
            Loaded = true;                 
        }

        public void Fire()
        {
            if (!Loaded)
                return;

            Loaded = false;

            CreateBullet();

            World.Instance.AddEvent(new ReloadGunEvent() { GameObject = this }, ReloadTime);
        }

        private void CreateBullet()
        {
            Bullet bullet = new Bullet();
            bullet.Left = Owner.CenterPoint.X;
            bullet.Top = Owner.CenterPoint.Y;
            bullet.Accelerate(10, RotationAngle);
        }
    }
}
