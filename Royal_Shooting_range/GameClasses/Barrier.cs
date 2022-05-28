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
        public float x, y;
        public Size scale;
        public Arrow stackedArrow;
        public Barrier(float x, float y)
        {
            this.scale = new Size(68, 100);
            this.x = x;
            this.y = y;
            stackedArrow = new Arrow(10000, 10000, 0, 0.2f);
        }

        public void Update()
        {
           
        }
    }
}
