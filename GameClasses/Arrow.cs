using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Royal_Shooting_range
{
    public class Arrow
    {
        public float x, y;
        public bool IsUp = false;
        public float angle;
        public Size scale;
        public float Speed;

        public Arrow(float x, float y, float angle, float speed)
        {
            this.scale = new Size(120, 75);
            this.x = x;
            this.y = y;
            this.angle = angle;
            this.Speed = speed;
        }

        public void Update(bool IsSecondTime)
        {
            if (IsSecondTime)
            {
                x += 5;
                y += angle / 10;
            }
            else
            {
                if (IsUp)
                {
                    angle -= Speed;
                    if (angle <= (float)(-45f))
                        IsUp = false;
                }
                else
                {
                    angle += Speed;
                    if (angle >= (float)(20f))
                        IsUp = true;
                }
            }
        }
    }
}
