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
        public Arrow stackedArrow;
        private Drawer drawer;
        public Target[] targets;
        public Player player;
        public Barrier[] barriers;
        public Level level;
        public Controller controller;
        public static readonly int WidthScreen = Screen.PrimaryScreen.WorkingArea.Width;
        public static readonly int HeightScreen = Screen.PrimaryScreen.WorkingArea.Height;
        public bool IsEightFrame;
        public bool IsSecondTime;

        public Game()
        {
            level = new Level();
            targets = new Target[] { };
            barriers = new Barrier[] { };
            controller = new Controller();
            drawer = new Drawer();
            player = new Player(0, HeightScreen - 154 * 2 + 14);
            arrow = new Arrow(player.x+250f, player.y+100, 0, level.ArrowSpeed);
        }
        public void Update(bool isSpacePressed, bool isSecondTime, Level curLevel)
        {
            IsSecondTime = isSecondTime;
            if (curLevel != null)
                this.level = curLevel;

            arrow.Speed = level.ArrowSpeed;

            if (arrow.x >= Game.WidthScreen || arrow.y >= 1.5 * Game.HeightScreen - player.y || arrow.y <= 0)
                Annulate();

            for (var i = 0; i < targets.Length; i++)
            {
                var target = targets[i];
                var conditionTarget = arrow.x + arrow.scale.Width <= target.x + 20 &&
                                      arrow.x + arrow.scale.Width > target.x - 20 &&
                                      arrow.y <= target.y + target.scale.Height - 20 &&
                                      arrow.y > target.y - target.scale.Height + 20;
                if (!Equals(target.Direction, "") && level.count!=0)
                {
                    target.Update(target);
                    if (conditionTarget)
                    {
                        targets[i] = new Target(float.MaxValue, float.MaxValue, "", 0, 0);
                        level.count--;
                        Annulate();
                    }
                }
            }

            for (var i = 0; i < barriers.Length; i++)
            {
                var barrier = barriers[i];
                var conditionBarrier = arrow.x + arrow.scale.Width <= barrier.x + 20 &&
                                       arrow.x + arrow.scale.Width > barrier.x - 20 &&
                                       arrow.y <= barrier.y + barrier.scale.Height + 10 &&
                                       arrow.y > barrier.y - 30;
                if (conditionBarrier)
                {
                    stackedArrow = new Arrow(arrow.x + 30, arrow.y + 7 * (arrow.angle / 10), arrow.angle, 0.2f);
                    barrier.stackedArrows.Add(stackedArrow);
                    Annulate();
                }
            }

            if (isSpacePressed)
                MakeIfSpaceDown();
            else MakeIfSpaceUp();

            if (player.currFrame / 4 == 8 && player.currAnimation == 0)
                IsEightFrame = true;

            drawer.Update();
            player.Update(player);
        }

        private void Annulate()
        {
            IsEightFrame = false;
            GameForm.isFirstTime = false;
            GameForm.isSecondTime = false;
            GameForm.isSpacePressed = false;
            GameForm.isFire = false;
            arrow.x = player.x + 250;
            arrow.y = player.y + 100;
            arrow.angle = 0;
            player.currAnimation = 1;
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
