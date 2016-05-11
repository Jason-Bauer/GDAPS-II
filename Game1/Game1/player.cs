using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{      

    class Player : RectangleClass
    {
        //  fields
        KeyboardState kbstate;
        public bool jumping = false;
        int jumpspeed = 0;

        //  properties
        public int Jumpspeed
        {
            get { return jumpspeed; }
            set { jumpspeed = value; }
        }

        public int Left
        {
            get { return this.X; }
        }

        public int Right
        {
            get { return (this.X + this.Width); }
        }

        public int Top
        {
            get { return this.Y; }
        }

        public int Bottom
        {
            get { return (this.Y + this.Height); }
            set { Bottom = value; }

        }

        //  constructor
        public Player(int x, int y, int width, int height): base(x, y, width, height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        /// <summary>
        /// This method checks if the player is currently jumping and whether the character can jump
        /// </summary>
        public void jumpcheck()
        {
            kbstate = Keyboard.GetState();
            if (jumping)
            {                
                position.Y += jumpspeed;    //Making it lose upward speed, then starts falling
                Jumpspeed++;
                
                if (jumpspeed >= 10)
                {
                    jumpspeed = 10; // max falling speed
                }    
            }
            else
            {
                //  check if the spacebar has been pressed
                if (kbstate.IsKeyDown(Keys.Space))
                {
                    jumping = true;
                    jumpspeed = -25;    //Give it upward thrust
                }
            }           
        }    
    }
}
