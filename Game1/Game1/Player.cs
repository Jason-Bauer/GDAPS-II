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

    class player : Class1
    {
        KeyboardState kbstate;
       public bool jumping = false;
        int jumpspeed = 0;

        
        
        
        public player(int x, int y, int width, int height)
            : base(x, y, width, height)
        {
            
        }
        public void jumpcheck()
        {
            kbstate = Keyboard.GetState();
            if (jumping)
            {
                
                position.Y += jumpspeed;//Making it go up
                jumpspeed += 1;//Some math (explained later)
                if (jumpspeed >= 20) { jumpspeed = 10; }
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
