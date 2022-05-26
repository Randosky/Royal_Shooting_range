using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Royal_Shooting_range.GameClasses;

namespace Royal_Shooting_range
{
    public class Controller
    {
        public Arrow arrow;
        public Player player;
        public Controller()
        {
        }

        public void Update(Player player)
        {
            this.player = player;
        }
        public void MakeIfSpaceDown()
        {
            //if (game.arrow.angle < Math.PI / 2 && game.arrow.IsUp == false)
            //{
            //    game.arrow.angle += 0.1f;
            //    game.arrow.IsUp = true;
            //}

            //if (game.arrow.IsUp)
            //{
            //    game.arrow.angle -= 0.1f;
            //    if (game.arrow.angle > -Math.PI / 2)
            //        game.arrow.IsUp = false;
            //}
            player.currAnimation = 0;
        }

        public void MakeIfSpaceUp()
        {
            player.currAnimation = 1;
        }
    }
}
