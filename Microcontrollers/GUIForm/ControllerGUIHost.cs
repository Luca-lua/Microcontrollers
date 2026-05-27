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
        private static Vector2 ?interaction = new();
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
                _form.control.MouseUp += (sender, e) =>
                {
                    interaction = null;
                };
                _form.control.MouseDown += (sender, e) =>
                {
                    interaction = new Vector2(e.X, e.Y);
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
            if(interaction == null || interaction == new Vector2(0,0))
            {
                click_r = null;
                return false;
            }
            else
            {
                click_r = new Vector2(interaction.Value.X, interaction.Value.Y);
                return true;
            }
        }
    }
}

