using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royal_Shooting_range.GameClasses
{
    public class Barrier
    {
        public int x, y;
        public Size scale;
        public Barrier(int x, int y)
        {
            this.scale = new Size(68, 100);
            this.x = x;
            this.y = y;
        }

        public void Update()
        {
           
        }
    }
}
