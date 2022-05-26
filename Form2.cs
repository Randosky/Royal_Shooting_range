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
using Royal_Shooting_range.GameClasses;
using Timer = System.Windows.Forms.Timer;

namespace Royal_Shooting_range
{
    public class Form2 : Form
    {
        private Timer timer1;
        private Timer popWindowTimer;
        private Controller controller;
        private Drawer drawer;
        private Game game;
        public PauseMenu pauseMenu;
        public static IEnumerable<Level> Levels;
        public Level currentLevel;
        public bool OnPause;
        public TableLayoutPanel Menu;
        private bool IsSpacePressed;
        private bool IsFirstTime;

        public Form2()
        {
            InitialiseForm();

            Levels = Level.CreateLevels();
            game = new Game();
            pauseMenu = new PauseMenu();
            currentLevel = new Level();
            Menu = pauseMenu.CreateMenu();

            popWindowTimer = new Timer();
            popWindowTimer.Interval = 3000;
            popWindowTimer.Start();
            var popWindow = new Label()
            {
                Text = "Choose Level",
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
            SelectLevel();
            InitialiseObjects();
        }

        public void SelectLevel()
        {
            var top = 10;
            foreach (var level in Form2.Levels)
            {
                if (currentLevel == null) currentLevel = level;
                var link = new LinkLabel
                {
                    Text = level.Name,
                    Font = new Font(FontFamily.GenericSerif, 10, FontStyle.Underline),
                    Left = 10,
                    Top = top,
                    BackColor = Color.Transparent
                };
                link.LinkClicked += (sender, args) => ChangeLevel(level);
                link.Parent = this;
                Controls.Add(link);
                top += link.PreferredHeight + 10;
            }
        }
        public void ChangeLevel(Level level)
        {
            currentLevel = level;
            game.barrier = level.Barrier;
            game.targets = level.Targets;
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


        public void InitialiseForm()
        {
            controller = new Controller();
            drawer = new Drawer();
            game = new Game();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            ControlBox = false;
            KeyPreview = true;
            this.KeyUp += new KeyEventHandler(UpKey);
            this.KeyDown += new KeyEventHandler(DownKey);
            this.Paint += new PaintEventHandler(OnPaint);
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        private void InitialiseObjects()
        {
            timer1 = new Timer();
            timer1.Interval = 200;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            if (currentLevel == null) return;
            game.Update(IsSpacePressed);
            pauseMenu.Update(CreateGraphics(), OnPause);
            if (pauseMenu.IsCompleted)
            {
                Controls.Add(Menu);
                pauseMenu.Continue.MouseClick += (s, args) =>
                {
                    OnPause = false;
                    pauseMenu.IsCompleted = false;
                };
                pauseMenu.Exit.MouseClick += (s, args) =>
                {
                    this.Close();
                };
                foreach (var control in Controls)
                {
                    if (control.GetType() == typeof(LinkLabel))
                    {
                        var cl = control as Control;
                        cl.Hide();
                    }
                }
            }
            else
            {
                Controls.Remove(Menu);
                foreach (var control in Controls)
                {
                    if (control.GetType() == typeof(LinkLabel))
                    {
                        var cl = control as Control;
                        cl.Show();
                    }
                }
            }
            Invalidate();
        }


        private void UpKey(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if(!IsFirstTime)
                        IsSpacePressed = false;
                    break;
            }
        }

        private void DownKey(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    IsFirstTime = true;
                    if (IsSpacePressed) IsFirstTime = false;
                    IsSpacePressed = true;
                    break;
                case Keys.Escape:
                    OnPause = true;
                    break;
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            drawer.DrawGame(g, game);
        }
    }
}
