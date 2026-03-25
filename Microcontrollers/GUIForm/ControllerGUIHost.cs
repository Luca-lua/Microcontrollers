using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp.Views.Desktop;
using System.Threading;
using System.Windows.Forms;
using Microcontrollers.ControllerGUI;

namespace Microcontrollers.GFX
{
    internal class ControllerGUIHost
    {
        private static int width { get; set; } = 600;
        private static int height { get; set; } = 200;
        private static Thread? _uiThread;
        private static ControllerGUIForm? _form;

        public static Action<SKCanvas>? OnDraw;

        public static void Show(int window_width, int window_height)
        {
            width = window_width;
            height = window_height;
            if (_uiThread != null) return;

            _uiThread = new Thread(() =>
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                _form = new ControllerGUIForm(width, height);
                _form.OnDraw = canvas => OnDraw?.Invoke(canvas);

                Application.Run(_form);
            });

            _uiThread.SetApartmentState(ApartmentState.STA);
            _uiThread.Start();
        }

        public static void Redraw()
        {
            _form?.Invoke(() => _form.Redraw());
        }
    }
}

