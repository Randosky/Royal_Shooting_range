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
        public List<Arrow> stackedArrows;
        public Barrier(float x, float y)
        {
            this.scale = new Size(68, 100);
            this.x = x;
            this.y = y;
            stackedArrows = new List<Arrow>();
            stackedArrows.Add(new Arrow(100000, 10000, 0.2f, 0.5f));
        }

        public void Update()
        {
           
        }
    }
}
