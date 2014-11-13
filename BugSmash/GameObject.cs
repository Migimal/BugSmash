using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugSmash
{
    abstract class GameObject
    {
        //based off of tank gamePiece class
        //gives x and y properties to game objects
        protected int x;
        protected int y;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }

        public GameObject(int newX, int newY)
        {
            x = newX;
            y = newY;
        }
    }
}
