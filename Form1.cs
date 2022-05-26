using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace Royal_Shooting_range
{
    public partial class Form1 : Form
    {
        private Map map = new Map(10);
        private Image grass = global::Postrelyski_Pokatyshki.Resource1.Grass;
        private Image sky = global::Postrelyski_Pokatyshki.Resource1.BackgroundSky;
        private Form2 form2 = new Form2();
        private PictureBox background = new PictureBox()
        {
            Image = global::Postrelyski_Pokatyshki.Resource1.Зд,
            Dock = DockStyle.Fill,
            AutoSize = true,
            SizeMode = PictureBoxSizeMode.StretchImage
        };
        private readonly TableLayoutPanel onStartPanel = new TableLayoutPanel()
        {
            Dock = DockStyle.Fill,
            BackColor = Color.Transparent,
            Padding = new Padding(200),
            RowStyles = { new RowStyle(SizeType.Percent, 1) }
        };
        private readonly LinkLabel linkLabel = new LinkLabel()
        {
            Text = $"Да, конечно",
            ActiveLinkColor = Color.LimeGreen,
            LinkColor = Color.Black,
            TextAlign = ContentAlignment.MiddleCenter,
            Font = new Font(FontFamily.GenericSerif, 30),
            Dock = DockStyle.Fill,
            AutoSize = true
        };

        public Form1()
        {
            Parallel.Invoke(() => ShowOnStart(), () => InitialiseForm());
        }

        private void ShowOnStart()
        {
            Controls.Add(background);
            onStartPanel.Controls.Add(new Label
            {
                Text = "Приветствую в игре \n\"Royal shooting range\"!" + "\n" + "Ты готов пострелять?",
                ForeColor = Color.Black,
                Dock = DockStyle.Fill,
                Font = new Font(FontFamily.GenericSerif, 45),
                Margin = new Padding(20),
                TextAlign = ContentAlignment.MiddleCenter
            });

            onStartPanel.Controls.Add(linkLabel);
            background.Controls.Add(onStartPanel);
            linkLabel.MouseClick += (sender, args) =>
            {
                this.Closing += (obj, e) => { form2.ShowDialog();};
                this.Close();
            };
        }

        public void InitialiseForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            ControlBox = false;
            KeyPreview = true;
            this.KeyDown += new KeyEventHandler(DownKey);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void DownKey(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}
