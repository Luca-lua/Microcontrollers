using Newtonsoft;
using ScematicEditor;
using ScematicEditor.Diagram;
using SkiaSharp;
using SkiaSharp.Views.Desktop;
using System.Numerics;

namespace ScematicEditor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

namespace ScematicEditor
{
    public partial class MainForm : Form
    {
        private readonly SKControl skControl;
        private List<MouseButtons> buttonstatus = new List<MouseButtons> { };
        private Vector2 mousepos = new Vector2(0, 0);
        int height = 1080 / 2;
        int width = 1920 / 2;
        private readonly JsonDiagramHandler diagram = new JsonDiagramHandler("C:\\Users\\E2658\\source\\repos\\Microcontrollers\\Controllers_Console_tester\\bin\\Debug\\net10.0-windows\\scematic.json");

        public MainForm()
        {
            this.Width = width;
            this.Height = height;
            Position.Position_setup("./diagram_positions.json");
            Position.ReadJson();
            skControl = new SKControl
            {
                Dock = DockStyle.Fill
            };
            skControl.PaintSurface += DoPaint;

            skControl.MouseMove += SkControl_MouseMove;
            skControl.MouseDown += SkControl_MouseDown;
            skControl.MouseUp += SkControl_MouseUp;

            Controls.Add(skControl);

            var refreshTimer = new System.Windows.Forms.Timer
            {
                Interval = 16
            };
            refreshTimer.Tick += (s, e) => skControl.Invalidate();
            refreshTimer.Start();
        }

        private void SkControl_MouseMove(object? sender, MouseEventArgs e)
        {
            mousepos = new Vector2(e.Location.X,e.Location.Y);
        }

        private void SkControl_MouseUp(object? sender, MouseEventArgs e)
        {
            buttonstatus.Add(e.Button);
        }

        private void SkControl_MouseDown(object? sender, MouseEventArgs e)
        {
            buttonstatus.Remove(e.Button);
        }

        private void DoPaint(object? sender, SKPaintSurfaceEventArgs e) 
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear();

            Scematiccontainer container = diagram.CreateScematicContainer();
            Drawing.DrawDiagram(this,canvas,container);
            Position.WriteJson();
        }
    }
}
