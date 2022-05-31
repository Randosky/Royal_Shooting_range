using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Royal_Shooting_range.GameClasses;

namespace Royal_Shooting_range
{
    public class Target
    {
        public float x, y;
        public Size scale;
        public bool OnStart;
        public string Direction;
        public float time;
        public float Speed;
        public float Radius;
        public int count;

        public Target(float x, float y, string direction, float radius, float speed)
        {
            this.scale = new Size(50, 50);
            this.x = x;
            this.y = y;
            this.Direction = direction;
            OnStart = true;
            time = 0;
            count = 0;
            this.Speed = speed;
            this.Radius = radius;
        }

        public void Update(Target target)
        {
            if (OnStart)
                OnStart = false;
            time += 0.1f;

            switch (target.Direction)
            {
                case "Down":
                    target.y -= Speed;
                    if (target.y < 100)
                        target.Direction = "Up";
                    break;
                case "Up":
                    target.y += Speed;
                    if (target.y > 600)
                        target.Direction = "Down";
                    break;
                case "Round":
                    target.x = (float)(target.x + Math.Cos(time * Radius) * Speed * 1.5);
                    target.y = (float)(target.y + Math.Sin(time * Radius) * Speed);
                    break;
                case "Round1":
                    target.x = (float) (target.x + Math.Cos(time * Radius) * Speed * 1.5);
                    target.y = (float) (target.y + Math.Sin(time) * Speed);
                    break;
                case "Round2":
                    target.x = (float)(target.x + Math.Cos(time) * Speed * 1.5);
                    target.y = (float)(target.y + Math.Sin(time * Radius) * Speed);
                    break;
                case "Round3":
                    target.x = (float)(target.x + Math.Cos(time * Radius) * Speed * 1.5);
                    target.y = (float)(target.y + Math.Sin(time * Radius) * Speed);
                    count++;
                    if (count > 3)
                    {
                        target.Direction = "Round4";
                        count = 0;
                    }
                    break;
                case "Round4":
                    target.x = (float)(target.x + Math.Cos(time * Radius) * Speed * 1.5);
                    target.y = (float)(target.y + Math.Sin(time) * Speed);
                    count++;
                    if (count > 3)
                    {
                        target.Direction = "Round5";
                        count = 0;
                    }
                    break;
                case "Round5":
                    target.x = (float)(target.x + Math.Cos(time) * Speed * 1.5);
                    target.y = (float)(target.y + Math.Sin(time * Radius) * Speed);
                    count++;
                    if (count > 3)
                    {
                        target.Direction = "Round3";
                        count = 0;
                    }
                    break;
            }
        }
    }
}
