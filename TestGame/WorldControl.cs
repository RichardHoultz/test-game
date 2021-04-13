using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace TestGame
{
    class WorldControl : Control
    {        
        Bitmap m_OffScreenBitmap;
        Timer m_Timer;
        int m_UpdateInterval = 40;
        Ship m_Ship;
        Graphics m_OffScreenGraphics;

        public WorldControl()
        {
            CreateWorldObjects();
        }

        private void CreateWorldObjects()
        {
            m_Ship = new Ship() { Top = 200, Left = 200 };                      
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (!Visible)
            {
                StartTimer();
            }
        }

        private void StartTimer()
        {
            m_Timer = new Timer();
            m_Timer.Interval = m_UpdateInterval;
            m_Timer.Tick += OnTimerTick;
            m_Timer.Start();
        }

        void OnTimerTick(object sender, EventArgs e)
        {
            World.Instance.DoTime(m_UpdateInterval);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            SetupOffScreenBitmap();
            m_OffScreenGraphics = Graphics.FromImage(m_OffScreenBitmap);
            World.Instance.Paint(m_OffScreenGraphics);

            e.Graphics.DrawImageUnscaled(m_OffScreenBitmap, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //Do nothing
        }

        protected void SetupOffScreenBitmap()
        {
            if (m_OffScreenBitmap != null)
            {
                if (m_OffScreenBitmap.Width != Width || m_OffScreenBitmap.Height != Height)
                {
                    m_OffScreenBitmap.Dispose();
                    m_OffScreenBitmap = null;
                }
            }

            if (m_OffScreenBitmap == null)
            {
                m_OffScreenBitmap = new Bitmap(Width, Height, PixelFormat.Format16bppRgb555);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            World.Instance.Width = Width;
            World.Instance.Height = Height;
        }        
    }
}
