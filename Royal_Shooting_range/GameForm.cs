using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Postrelyski_Pokatyshki.GameClasses;
using Royal_Shooting_range.GameClasses;
using Timer = System.Windows.Forms.Timer;

namespace Royal_Shooting_range
{
    public class GameForm : Form
    {
        private Timer timer1;
        private Timer popWindowTimer;
        private Controller controller;
        private Drawer drawer;
        public static Game game;
        private PauseMenu pauseMenu;
        public static IEnumerable<Level> Levels;
        public Level currentLevel;
        public static bool OnPause;
        public new TableLayoutPanel Menu;
        public static bool isSpacePressed;
        public static bool isFirstTime;
        public static bool isSecondTime;
        public static bool isFire;
        public static bool isReset;
        public StartWindow startWindow;
        public static bool isStartWindow = true;
        private CompletedLevel completedLevel;
        private Tutorial tutorial;

        public GameForm()
        {
            InitialiseForm();
            InitialiseObjects();

            if (isStartWindow)
            {
                Controls.Add(startWindow.CreateStartWindow());
                startWindow.Continue.MouseClick += (s, args) =>
                {
                    this.Controls.Remove(startWindow.Window);
                    isStartWindow = false;
                };

                startWindow.Tutorial.MouseClick += (s, args) =>
                {
                    this.Controls.Remove(startWindow.Window);
                    this.Controls.Add(tutorial.CreateTutorialWindow());
                    tutorial.Exit.MouseClick += (sender, eventArgs) => this.Close();
                    tutorial.Continue.MouseClick += (sender, eventArgs) => this.Controls.Remove(tutorial.Window);
                };

                startWindow.Exit.MouseClick += (s, args) => this.Close();
            }

            SelectLevel();
        }

        public void InitialiseForm()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            ControlBox = false;
            KeyPreview = true;
            this.KeyUp += (sender, args) => controller.UpKey(sender, args);
            this.KeyDown += (sender, args) => controller.DownKey(sender, args);
            this.Paint += new PaintEventHandler(OnPaint);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void InitialiseObjects()
        {
            timer1 = new Timer { Interval = 10 };
            timer1.Tick += new EventHandler(Update);
            timer1.Start();

            Levels = Level.CreateLevels();
            game = new Game();
            drawer = new Drawer();
            controller = new Controller();
            pauseMenu = new PauseMenu();
            currentLevel = new Level();
            completedLevel = new CompletedLevel();
            popWindowTimer = new Timer();
            tutorial = new Tutorial();
            startWindow = new StartWindow();
            Menu = pauseMenu.CreateMenu();
        }

        private void Update(object sender, EventArgs e)
        {
            if (currentLevel == null) return;
            else if (currentLevel.count == 0 && game.barriers.Length != 0)
                Controls.Add(completedLevel.CompletedLabel);

            game.Update(isSpacePressed, isSecondTime, currentLevel);

            pauseMenu.Update(CreateGraphics(), OnPause);
            if (pauseMenu.IsCompleted)
            {
                Controls.Add(Menu);
                pauseMenu.Continue.MouseClick += (s, args) =>
                {
                    OnPause = false;
                    pauseMenu.IsCompleted = false;
                };
                pauseMenu.Exit.MouseClick += (s, args) => this.Close();
                HideLevels();
            }
            else
            {
                Controls.Remove(Menu);
                ShowLevels();
            }
            Invalidate();
        }

        public void SelectLevel()
        {
            var top = 10;
            foreach (var level in Levels)
            {
                if (currentLevel == null)
                    currentLevel = level;
                var link = new LinkLabel
                {
                    Text = level.Name,
                    Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Underline),
                    Left = 10,
                    Top = top,
                    BackColor = Color.Transparent,
                    LinkColor = Color.LawnGreen,
                };
                link.LinkClicked += (sender, args) => ChangeLevel(level);
                link.Parent = this;
                Controls.Add(link);
                top += link.PreferredHeight + 10;
            }

            var reset = new LinkLabel
            {
                Text = "Reset",
                Font = new Font(FontFamily.GenericSerif, 12, FontStyle.Underline),
                Left = 10,
                Top = top,
                BackColor = Color.Transparent,
                LinkColor = Color.LawnGreen
            };
            reset.LinkClicked += (sender, args) =>
            {
                isReset = true;
                foreach (var barrier in game.barriers)
                    barrier.stackedArrow = new Arrow(10000, 10000, 0, 0.2f);
                RemoveLevels();
                Levels = Level.CreateLevels();
                SelectLevel();
            };
            Controls.Add(reset);
        }
        public void ChangeLevel(Level level)
        {
            Controls.Remove(completedLevel.CompletedLabel);
            isReset = false;
            currentLevel = level;
            game.barriers = level.Barriers;
            game.targets = level.Targets;
            foreach (var barrier in game.barriers)
                barrier.stackedArrow = new Arrow(10000, 10000, 0, 0.2f);
            PopWindow();
        }

        private void PopWindow()
        {
            popWindowTimer.Interval = 1000;
            popWindowTimer.Start();
            var popWindow = new Label()
            {
                Text = currentLevel.Name,
                Font = new Font(FontFamily.GenericSerif, 75),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            Controls.Add(popWindow);
            popWindowTimer.Tick += (sender, args) =>
            {
                Controls.Remove(popWindow);
                popWindowTimer.Stop();
            };
        }

        private void RemoveLevels()
        {
            foreach (var control in Controls)
            {
                if (control.GetType() == typeof(LinkLabel))
                {
                    var cl = control as Control;
                    Controls.Remove(cl);
                }
            }
        }

        private void ShowLevels()
        {
            foreach (var control in Controls)
            {
                if (control.GetType() == typeof(LinkLabel))
                {
                    var cl = control as Control;
                    cl.Show();
                }
            }
        }

        private void HideLevels()
        {
            foreach (var control in Controls)
            {
                if (control.GetType() == typeof(LinkLabel))
                {
                    var cl = control as Control;
                    cl.Hide();
                }
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            drawer.DrawGame(g, game);
        }
    }
}
