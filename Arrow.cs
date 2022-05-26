using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royal_Shooting_range
{
    public class Arrow
    {
        public int x, y;
        public bool IsUp = false;
        public float angle;
        public Size scale;

        public Arrow(int x, int y, float angle)
        {
            this.scale = new Size(100, 31);
            this.x = x;
            this.y = y;
            this.angle = angle;
        }

        public void Update(Arrow arrow)
        {
            if (arrow.IsUp)
            {
                arrow.angle -= 0.1f;
                if (arrow.angle <= (float)( - Math.PI / 2))
                    arrow.IsUp = false;
            }
            else
            {
                arrow.angle += 0.1f;
                if (arrow.angle >= (float)(Math.PI / 2))
                    arrow.IsUp = true;
            }
        }
    }
}
