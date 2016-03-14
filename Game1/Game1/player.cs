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

    class Player : Class1
    {
        KeyboardState kbstate;
        public bool jumping = false;
        int jumpspeed = 0;
        public bool falling;    //  if the player is falling, he cannot jump

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
                position.Y += jumpspeed;//Making it go up
                
                if (jumpspeed >= 20) { jumpspeed = 20; }
            }
            else
            {
                if (kbstate.IsKeyDown(Keys.Space))
                {
                    jumping = true;
                    jumpspeed = -20;//Give it upward thrust
                }
            }           
        }    
    }
}
