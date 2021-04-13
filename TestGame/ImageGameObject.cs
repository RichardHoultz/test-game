using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace TestGame
{
    class ImageGameObject: GameObject
    {
        public Image Image { set; get; }       

        public ImageGameObject()
        {
        }

        internal override void Paint(Graphics graphics)
        {
            if (Image == null)
                return;
            
            //Setup tranforms to draw image rotated
            graphics.TranslateTransform((Left + Width / 2), (Top + Height / 2));
            graphics.RotateTransform(RotationAngle);
            graphics.TranslateTransform(-(Left + Width / 2), -(Top + Height / 2));

            Rectangle destinationRectangle = new Rectangle((int)Left, (int)Top, (int)Width, (int)Height);
            Rectangle sourceRectangle = new Rectangle(0, 0, (int)Width, (int)Height);
            graphics.DrawImage(Image, Left, Top, sourceRectangle, GraphicsUnit.Pixel);

            graphics.ResetTransform();
        }
    }
}
