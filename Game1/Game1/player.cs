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
        KeyboardState kbstate;
        public bool jumping = false;
        int jumpspeed = 0;

        //  properties
        public int Jumpspeed
        {
            get { return jumpspeed; }
            set { jumpspeed = value; }
        }

                        
        public Player(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            
        }
        public void jumpcheck()
        {
            kbstate = Keyboard.GetState();
            if (jumping)
            {                
                position.Y += jumpspeed;    //Making it lose upward speed, then starts falling
                
                if (jumpspeed >= 20)
                {
                    jumpspeed = 20; // max falling speed
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
