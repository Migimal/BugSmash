using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugSmash
{
    class Bug : MovingGameObject
    {
        public int movement;
        public bool dead = false;
        private MouseState oldState;
        //prevents similar random numbers
        Random random = new Random(Guid.NewGuid().GetHashCode());
        public bool Dead { get { return dead; } set { dead = value; } }

        public Bug(int x, int y, int dir)
            : base(x, y, dir)
        {
        }
        public bool Move()
        {
            //if on left wall
            if (this.x < Vars.screenWidth / 16 && this.y < (Vars.screenHeight * 85) / 100) direction = 1;
            //if on bottom of screen
            else if (this.y > ((Vars.screenHeight * 85) / 100) && this.x > ((Vars.screenHeight * 15) / 100)) direction = 0;
            //if on blanket
            else if (((this.x > 0 && (this.x <= Vars.screenWidth / 5)) && (this.y > (Vars.screenHeight * 2) / 3) && this.y < Vars.screenHeight)) return true;
            //regular movement
            //guides bug toward blanket every couple of moves
            else
            {
                switch (random.Next(0, 2))
                {
                    case 0: direction = direction; break;
                    case 1: direction = random.Next(2, 4); break;
                }
            }

            movement = random.Next(0, ((Vars.screenWidth / 90)));
            //moves bug based on direction it's facing
            switch (direction)
            {
                case 0: y -= movement; break;
                case 1: x += movement; break;
                case 2: y += movement; break;
                case 3: x -= movement; break;
            }
            return false;
        }
        //checks if you clicked on the bug
        //kills the bug if you clicked it
        public void checkDeath()
        {
            MouseState newState = Mouse.GetState();

            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                if ((((newState.X >= this.x) && (newState.X <= (this.X + (Vars.screenWidth / 16)))) && (newState.Y >= this.Y) && (newState.Y <= (this.y + (Vars.screenWidth / 16)))))
                {
                    this.dead = true;
                }
            }
            oldState = newState;
        }
    }
}
