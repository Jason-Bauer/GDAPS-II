using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    //  This class will control the creation and locations of the platforms
    class Platform: Class1
    {
        //  attributes
        int[] locY = new int[10];

        //  constructor
        public Platform(int x, int y, int width, int height) : base(x, y, width, height)
        {

        }


        /// <summary>
        ///  this method will populate the array the array of platform y positions
        /// </summary>
        /// <param name="y">this is the height of the game screen</param>
        public void platformY(int y)
        {
            for(int i = 0; i < locY.Count(); i++)
            {
                if( i == 0)
                {
                    locY[i] = y - (y / 11);
                }
                else
                {
                    locY[i] = locY[i - 1] - (y / 11);
                }
            }
        }


        //  this method will choose the location of the next platform
        public void platformLoc(int prevX, int prevY)   //  the parameters have the coordinates of the previous platform, so it is possible for the player to make the jump
        {

        }


    }
}
