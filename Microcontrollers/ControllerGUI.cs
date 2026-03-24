using System.Windows.Forms;
using SkiaSharp;
using SkiaSharp.Views.Desktop;


namespace Microcontrollers
{
    public class ControllerGUI : Form
    {
        private SKControl control;
        internal Action<SKCanvas> OnDraw;

        public ControllerGUI(int widht, int height)
        {
            Width = widht;
            Height = height;
            control = new SKControl
            {
                Dock = DockStyle.Fill
            };
            control.PaintSurface += PaintSurface;
            Controls.Add(control);
        }
        public void Resize(int width, int height)
        {
            Width = width; Height = height; 
        }
        private void PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            OnDraw?.Invoke(canvas);
        }
        public void Redraw()
        {
            control.Invalidate();
        }
    }
}
