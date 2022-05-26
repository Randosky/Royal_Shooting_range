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
    public class Game
    {
        public Arrow arrow;
        private Drawer drawer;
        public Target[] targets;
        public Player player;
        public Map map;
        public Barrier barrier;
        public Level level;
        public Controller controller;
        public static readonly int WidthScreen = Screen.PrimaryScreen.WorkingArea.Width;
        public static readonly int HeightScreen = Screen.PrimaryScreen.WorkingArea.Height;
        public bool IsEightFrame;

        public Game()
        {
            player = new Player(0, HeightScreen - 154 * 2 + 14);
            arrow = new Arrow(player.x+250, player.y+100, 0);
            targets = new Target[]{};
            map = new Map(10);
            level = new Level();
            barrier = new Barrier(100000, 10000);
            controller = new Controller();
            drawer = new Drawer();
        }
        public void Update(bool IsSpacePressed)
        {
            for (var i = 0; i < targets.Length; i++)
            {
                var target = targets[i];
                target.Update(target, i % 2 != 0);
            }
            if(IsSpacePressed) MakeIfSpaceDown();
            else MakeIfSpaceUp();
            if (player.currFrame / 2 == 8 && player.currAnimation == 0)
                IsEightFrame = true;

            drawer.Update();
            arrow.Update(arrow);
            player.Update(player);
        }

        public void MakeIfSpaceDown()
        {
            player.currAnimation = 0;
        }

        public void MakeIfSpaceUp()
        {
            player.currAnimation = 1;
            if(IsEightFrame) player.currFrame = 2;
            IsEightFrame = false;
        }
    }
}
