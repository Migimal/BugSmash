using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugSmash
{
    class MenuScreen
    {
        //detects if the play button on menu screen is pressed
        public bool clicked = false;
        MouseState oldState;

        public void checkButton()
        {
            MouseState newState = Mouse.GetState();

            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                //checks if click is within boundaries of the button
                if ((newState.X >= ((Vars.screenWidth * 78) / 100) && newState.X <= (Vars.screenWidth) && (newState.Y >= ((Vars.screenHeight * 78) / 100) && newState.Y <= Vars.screenHeight)))
                {
                    this.clicked = true;
                }
                else if ((newState.X >= ((Vars.screenWidth * 0) / 100) && newState.X <= (Vars.screenWidth * 22) / 100 && newState.Y >= ((Vars.screenHeight * 78) / 100) && newState.Y <= (Vars.screenHeight)))
                {
                  //show external tool
                }
            }
            oldState = newState;
        }


    }
}
