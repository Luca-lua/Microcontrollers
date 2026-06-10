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
        int height = (int)(1080 / 1.5);
        int width = (int)(1920 / 1.5);
        internal static int offset_x = 0;
        internal static int offset_y = 0;
        internal static double zoom = 2;
        private static string path = JsonPath.readFile();
        private readonly JsonDiagramHandler diagram = new JsonDiagramHandler(path+ "scematic.json");
        private Scematiccontainer container;

        public MainForm()
        {
            this.Width = width;
            this.Height = height;
            Position.Position_setup(path + "diagram_positions.json");
            Position.ReadJson();
            skControl = new SKControl
            {
                Dock = DockStyle.Fill
            };
            skControl.PaintSurface += DoPaint;

            skControl.MouseMove += SkControl_MouseMove;
            skControl.MouseDown += SkControl_MouseDown;
            skControl.MouseUp += SkControl_MouseUp;
            skControl.MouseWheel += SkControl_MouseWheel;

            Controls.Add(skControl);

            var refreshTimer = new System.Windows.Forms.Timer
            {
                Interval = 16
            };
            refreshTimer.Tick += (s, e) => skControl.Invalidate();
            refreshTimer.Start();
        }

        private void SkControl_MouseWheel(object? sender, MouseEventArgs e)
        {
            if(e.Delta > 0 && MainForm.zoom != 0.25)
            {
                MainForm.zoom -= 0.25;
            }
            if(e.Delta < 0 && MainForm.zoom != 9.75)
            {
                MainForm.zoom += 0.25;
            }
        }

        private void SkControl_MouseMove(object? sender, MouseEventArgs e)
        {
            mousepos = new Vector2(e.Location.X,e.Location.Y);
        }

        private void SkControl_MouseUp(object? sender, MouseEventArgs e)
        {
            buttonstatus.Remove(e.Button);
        }

        private void SkControl_MouseDown(object? sender, MouseEventArgs e)
        {
            buttonstatus.Add(e.Button);
        }

        private void DoPaint(object? sender, SKPaintSurfaceEventArgs e) 
        {
            container = diagram.CreateScematicContainer();
            var canvas = e.Surface.Canvas;
            canvas.Clear();
            Camera.MoveCamera(buttonstatus, mousepos);
            Drawing.DrawDiagram(this, canvas, container);
            ScreenInterraction.MoveParts(buttonstatus, mousepos,container);
            Position.WriteJson();
            diagram.writeJsonFromScematiccontainer(container);
        }
    }
}
