using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Royal_Shooting_range.GameClasses;

namespace Royal_Shooting_range
{
    public class Target
    {
        public int x, y;
        public Size scale;
        public bool IsDown;
        public bool OnStart;
        public Target(int x, int y)
        {
            this.scale = new Size(50, 50);
            this.x = x;
            this.y = y;
            OnStart = true;
        }

        public void Update(Target target, bool IsDown)
        {
            if (OnStart)
            {
                target.IsDown = IsDown;
                OnStart = false;
            }

            if (target.IsDown)
            {
                target.y -= 4;
                if (target.y < 100)
                    target.IsDown = false;
            }

            if (!target.IsDown)
            {
                target.y += 4;
                if(target.y > 600)
                    target.IsDown = true;
            }
        }
    }
}
