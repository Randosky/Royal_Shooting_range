using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Royal_Shooting_range.GameClasses;
using Barrier = Royal_Shooting_range.GameClasses.Barrier;

namespace Royal_Shooting_range
{
    class Drawer
    {
        const int aW = 120;
        const int aH = 75;
        const int tW = 50;
        const int tH = 50;
        const int pW = 486;
        const int pH = 255;
        private Bitmap playerIm;
        private Bitmap targetIm;
        private Bitmap barrierIm;
        private Bitmap arrowIm;
        private Bitmap mapIm;
        private Bitmap grass;
        private Bitmap sky;

        public Drawer()
        {
            playerIm = global::Royal_Shooting_range.Resource1.AnimationArcher;
            targetIm = global::Royal_Shooting_range.Resource1.Target;
            arrowIm = global::Royal_Shooting_range.Resource1.ArrowAnimation;
            mapIm = global::Royal_Shooting_range.Resource1.Зд;
            grass = global::Royal_Shooting_range.Resource1.Grass;
            sky = global::Royal_Shooting_range.Resource1.BackgroundSky;
            barrierIm = global::Royal_Shooting_range.Resource1.Barrier;
        }

        public void Update()
        {
        }

        public void DrawGame(Graphics g, Game game)
        {
            DrawMap(g);
            if (!GameForm.isReset)
            {
                foreach (var target in game.targets)
                    if (!Equals(target.x, float.MaxValue) && !Equals(target.y, float.MaxValue))
                        DrawTarget(g, target);
                foreach (var barrier in game.barriers)
                {
                    foreach (var stackedArrow in barrier.stackedArrows)
                        DrawStackedArrow(g, stackedArrow);
                    DrawBarrier(g, barrier);
                }
            }
            if (game.IsEightFrame) DrawArrow(g, game.arrow, game.IsSecondTime);
            else DrawAnimation(g, game.player);
        }

        private void DrawBarrier(Graphics g, Barrier barrier)
        {
            var bW = barrier.scale.Width;
            var bH = barrier.scale.Height;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawImage(barrierIm, barrier.x, barrier.y, new Rectangle(0, 0, bW, bH), GraphicsUnit.Pixel);
        }

        private void DrawAnimation(Graphics g, Player player)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            switch (player.currAnimation)
            {
                case 0:
                    g.DrawImage(playerIm, 0, player.y, new Rectangle(pW * (10 - player.currFrame/4), pH * player.currAnimation, pW, pH), GraphicsUnit.Pixel);
                    break;
                case 1:
                    g.DrawImage(playerIm, 0, player.y, new Rectangle(pW * (10 - player.currFrame/4), pH * player.currAnimation, pW, pH), GraphicsUnit.Pixel);
                    break;
            }
        }

        public void DrawMap(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawImage(mapIm, 0, 0, Game.WidthScreen, Game.HeightScreen+55);
        }

        private void DrawTarget(Graphics g, Target target)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawImage(targetIm, target.x, target.y, new Rectangle(0, 0, tW, tH), GraphicsUnit.Pixel);
        }

        private void DrawArrow(Graphics g, Arrow arrow, bool IsSecondTime)
        {
            g.SmoothingMode = SmoothingMode.HighQuality;
            arrow.Update(IsSecondTime);
            var rotatedImage = RotateImage(arrowIm, arrow.angle);
            g.DrawImage(rotatedImage, arrow.x, arrow.y, new Rectangle(0, 0, aW, aH), GraphicsUnit.Pixel);
        }

        private void DrawStackedArrow(Graphics g, Arrow arrow)
        {
            var rotatedImage = RotateImage(arrowIm, arrow.angle);
            g.DrawImage(rotatedImage, arrow.x, arrow.y, new Rectangle(0, 0, aW, aH), GraphicsUnit.Pixel);
        }

        private Image RotateImage(Image img, float rotationAngle)
        {
            var bmp = new Bitmap(img.Width, img.Height);
            bmp.SetResolution(img.HorizontalResolution, img.VerticalResolution);
            var g = Graphics.FromImage(bmp);

            g.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            g.RotateTransform(rotationAngle);
            g.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(img, new Point(0, 0));

            g.Dispose();

            return bmp;
        }
    }
}
