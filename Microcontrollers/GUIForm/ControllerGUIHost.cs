using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp.Views.Desktop;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Concurrent;
using Microcontrollers.ControllerGUI;
using System.Numerics;
using Microsoft.VisualBasic;

namespace Microcontrollers.GFX
{
    internal class ControllerGUIHost
    {
        private static int width { get; set; } = 600;
        private static int height { get; set; } = 200;
        private static readonly ConcurrentQueue<Vector2> interactions = new();
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
                _form.control.MouseClick += (sender, e) =>
                {
                    interactions.Enqueue(new Vector2(e.X, e.Y));
                };

                Application.Run(_form);

            });

            _uiThread.SetApartmentState(ApartmentState.STA);
            _uiThread.Start();
        }
        public static void Redraw()
        {
            _form?.Invoke(() => _form.Redraw());
        }
        public static bool TryGetClick(out Vector2? click_r)
        {
            Vector2 click;
            bool result = interactions.TryDequeue(out click);
            if(click == new Vector2(0,0))
            {
                click_r = null;
                return false;
            }
            else
            {
                click_r = new Vector2(click.X, click.Y);
                return result;
            }
        }
    }
}

