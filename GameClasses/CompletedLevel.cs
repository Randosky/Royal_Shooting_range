using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Reflection.Emit.Label;

namespace Postrelyski_Pokatyshki.GameClasses
{
    public class CompletedLevel
    {
        public System.Windows.Forms.Label CompletedLabel;

        public CompletedLevel()
        {
            CompletedLabel = new System.Windows.Forms.Label()
            {
                Text = "Level Completed",
                Font = new Font(FontFamily.GenericSerif, 75),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
        }
    }
}
