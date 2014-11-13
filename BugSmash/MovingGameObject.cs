using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BugSmash
{
    abstract class MovingGameObject : GameObject
    {
        //based off of tank game movingPiece class
        //adds direction to bugs for movement
        protected int direction;
        public int Direction
        {
            get { return direction; }
            set
            {
                if (value >= 0 && value <= 3)
                    direction = value;
            }
        }
        public MovingGameObject(int x, int y, int dir)
            : base(x, y)
        {
            // Use the property to set the direction
            Direction = dir;
        }
    }
}
