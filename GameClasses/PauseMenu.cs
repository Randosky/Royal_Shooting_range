using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Royal_Shooting_range;

namespace Royal_Shooting_range.GameClasses
{
    public class PauseMenu
    {
        public bool IsCompleted;
        public bool IsStarted;
        private const int Delta = 45;
        private static Size size = new Size(10, 10);
        private TableLayoutPanel Menu;
        public PictureBox Continue;
        public PictureBox Exit;

        public PauseMenu()
        {
            IsCompleted = false;
            IsStarted = false;
        }

        public TableLayoutPanel CreateMenu()
        {
            Menu = new TableLayoutPanel()
            {
                Padding = new Padding(200),
                RowStyles = { new RowStyle(SizeType.AutoSize) },
                Dock = DockStyle.Fill,
                BackColor = Color.Aquamarine,
            };

            Continue = new PictureBox()
            {
                Image = global::Royal_Shooting_range.Resource1.Continue,
                AutoSize = true,
                Dock = DockStyle.Fill,
                Margin = new Padding(20),
            };

            Exit = new PictureBox()
            {
                Image = global::Royal_Shooting_range.Resource1.Exit,
                AutoSize = true,
                Dock = DockStyle.Fill,
                Margin = new Padding(20),
            };

            Menu.Controls.Add(Continue);
            Menu.Controls.Add(Exit);
            return Menu;
        }

        public void Update(Graphics g, bool onPause)
        {
            if (size.Width < 3 * Game.WidthScreen - 500 && size.Height < 3 * Game.HeightScreen - 500 && onPause)
            {
                IsStarted = true;
                size = new Size(size.Width + Delta, size.Height + Delta);
                Draw(g, onPause);
            }
            else if(IsStarted)
            {
                size = new Size(100, 100);
                IsCompleted = true;
                IsStarted = false;
            }
        }

        public void Draw(Graphics g, bool onPause)
        {
            if (onPause)
            {
                g.FillEllipse(new SolidBrush(Color.Aquamarine), Game.WidthScreen / 2 - size.Width / 2, Game.HeightScreen / 2 - size.Height / 2, size.Width, size.Height);
                Update(g, onPause);
            }
        }
    }
}