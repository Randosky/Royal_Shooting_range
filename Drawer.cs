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
        private Bitmap playerIm;
        private Bitmap targetIm;
        private Bitmap barrierIm;
        private Bitmap arrowIm;
        private Bitmap mapIm;
        private Bitmap grass;
        private Bitmap sky;

        public Drawer()
        {
            playerIm = global::Postrelyski_Pokatyshki.Resource1.AnimationArcher;
            targetIm = global::Postrelyski_Pokatyshki.Resource1.Target;
            arrowIm = global::Postrelyski_Pokatyshki.Resource1.ArrowAnimation;
            mapIm = global::Postrelyski_Pokatyshki.Resource1.BackgroundSky2;
            grass = global::Postrelyski_Pokatyshki.Resource1.Grass;
            sky = global::Postrelyski_Pokatyshki.Resource1.BackgroundSky;
            barrierIm = global::Postrelyski_Pokatyshki.Resource1.Barrier;
        }

        public void Update()
        {
        }

        public void DrawGame(Graphics g, Game game)
        {
            DrawMap(g, game.map);
            foreach (var target in game.targets)
                DrawTarget(g, target);
            DrawBarrier(g, game.barrier);
            if (game.IsEightFrame) DrawArrow(g, game.arrow);
            else DrawAnimation(g, game.player);
        }

        private void DrawBarrier(Graphics g, Barrier barrier)
        {
            var bW = barrier.scale.Width;
            var bH = barrier.scale.Height;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawImage(barrierIm, barrier.x, barrier.y, new Rectangle(0, 0, bW, bH), GraphicsUnit.Pixel);
        }

        private void DrawAnimation(Graphics g, Player player)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            var pW = player.scale.Width;
            var pH = player.scale.Height;
            switch (player.currAnimation)
            {
                case 0:
                    g.DrawImage(playerIm, 0, player.y, new Rectangle(pW * (10 - player.currFrame/2), pH * player.currAnimation, pW, pH), GraphicsUnit.Pixel);
                    break;
                case 1:
                    g.DrawImage(playerIm, 0, player.y, new Rectangle(pW * (10 - player.currFrame/2), pH * player.currAnimation, pW, pH), GraphicsUnit.Pixel);
                    break;
            }
        }

        public void DrawMap(Graphics g, Map map)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            for (int i = 0; i < map.Size; i++)
            {
                for (int j = 0; j < map.Size; j++)
                {
                    if (map.map[i, j] == 1)
                    {
                        g.DrawImage(grass, i * 154, j * 154);
                    }
                    if (map.map[i, j] == 2)
                    {
                        g.DrawImage(sky, i * 154, j * 154);
                    }
                }
            }
        }

        private void DrawTarget(Graphics g, Target target)
        {
            var tW = target.scale.Width;
            var tH = target.scale.Height;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawImage(targetIm, target.x, target.y, new Rectangle(0, 0, tW, tH), GraphicsUnit.Pixel);
        }

        private void DrawArrow(Graphics g, Arrow arrow)
        {
            var aW = arrow.scale.Width;
            var aH = arrow.scale.Height;
            g.SmoothingMode = SmoothingMode.HighQuality;
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
