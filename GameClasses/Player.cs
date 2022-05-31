using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royal_Shooting_range
{
    public class Player
    {
        public float x, y;
        public Size scale;
        public int currFrame = 0;
        public int currAnimation = Int32.MaxValue;

        public Player(float x, float y)
        {
            this.scale = new Size(486, 255);
            this.x = x;
            this.y = y;
        }

        public void Update(Player player)
        {
            player.currFrame++;
            if (player.currFrame == 40)
                player.currFrame = 4;
        }
    }
}
