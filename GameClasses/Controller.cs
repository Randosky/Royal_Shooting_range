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
        public void Update()
        {
            
        }
        public void UpKey(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (!GameForm.isFire)
                    {
                        if (!GameForm.isFirstTime && !GameForm.game.IsEightFrame)
                        {
                            GameForm.isSpacePressed = false;
                            GameForm.isSecondTime = false;
                        }
                    }
                    break;
            }
        }

        public void DownKey(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (!GameForm.isFire)
                    {
                        GameForm.isFirstTime = true;
                        if (GameForm.isSpacePressed) GameForm.isFirstTime = false;
                        GameForm.isSpacePressed = true;
                        if (GameForm.isSpacePressed && GameForm.game.IsEightFrame)
                            GameForm.isSecondTime = true;
                    }
                    break;
                case Keys.Escape:
                    GameForm.OnPause = true;
                    break;
            }
        }
    }
}
