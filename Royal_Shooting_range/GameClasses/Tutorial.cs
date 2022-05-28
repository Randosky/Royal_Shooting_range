using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Postrelyski_Pokatyshki.GameClasses
{
    public class Tutorial 
    {
        public TableLayoutPanel Window;
        private Label TutorialText;
        public PictureBox Continue;
        public PictureBox Exit;

        public TableLayoutPanel CreateTutorialWindow()
        {
            Window = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Aquamarine,
                Padding = new Padding(200),
                RowStyles = { new RowStyle(SizeType.Percent, 25) }
            };

            TutorialText = new Label()
            {
                Text = "Нажмите \"Space\", чтобы начать выстрел, когда стрела начнёт вращаться нажмите \"Space\" ещё раз, чтобы выстрелить\n\n" +
                       "Вы можете переключать уровни в левом верхнем углу экрана, а также обновить все уровни",
                Dock = DockStyle.Fill,
                BackColor = Color.Aquamarine,
                ForeColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D,
                Font = new Font(FontFamily.GenericSansSerif, 30, FontStyle.Regular, GraphicsUnit.Pixel)
            };

            Continue = new PictureBox()
            {
                Image = global::Postrelyski_Pokatyshki.Resource1.Continue,
                AutoSize = true,
                Dock = DockStyle.Fill,
                Margin = new Padding(20),
            };


            Exit = new PictureBox()
            {
                Image = global::Postrelyski_Pokatyshki.Resource1.Exit,
                AutoSize = true,
                Dock = DockStyle.Fill,
                Margin = new Padding(20),
            };

            Window.Controls.Add(TutorialText);
            Window.Controls.Add(Continue);
            Window.Controls.Add(Exit);
            return Window;
        }
    }
}
