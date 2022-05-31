using System.Drawing;
using System.Windows.Forms;
using ContentAlignment = System.Drawing.ContentAlignment;

namespace Postrelyski_Pokatyshki.GameClasses
{
    public class StartWindow
    {
        public TableLayoutPanel Window;
        private PictureBox Question;
        public PictureBox Continue;
        public PictureBox Tutorial;
        public PictureBox Exit;

        public TableLayoutPanel CreateStartWindow()
        {
            Window = new TableLayoutPanel()
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Aquamarine,
                Padding = new Padding(200),
                RowStyles = { new RowStyle(SizeType.Percent, 1) }
            };

            Question = new PictureBox()
            {
                Image = global::Royal_Shooting_range.Resource1.Question,
                AutoSize = true,
                Dock = DockStyle.Fill,
                Margin = new Padding(20),
            };

            Continue = new PictureBox()
            {
                Image = global::Royal_Shooting_range.Resource1.Continue,
                AutoSize = true,
                Dock = DockStyle.Fill,
                Margin = new Padding(20),
            };

            Tutorial = new PictureBox()
            {
                Image = global::Royal_Shooting_range.Resource1.Tutorial,
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

            Window.Controls.Add(Question);
            Window.Controls.Add(Continue);
            Window.Controls.Add(Tutorial);
            Window.Controls.Add(Exit);

            return Window;
        }
    }
}
