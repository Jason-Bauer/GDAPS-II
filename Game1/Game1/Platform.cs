using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game1
{
    //  This class will control the creation and locations of the platforms
    class Platform: RectangleClass
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


        /// <summary>
        /// this method will choose the location of the next platform
        /// </summary>
        /// <param name="prevY">the y coordinate of the last platform</param>
        /// <param name="screenX">the width of the game screen</param>
        /// <returns></returns>
        public Rectangle platformLoc(int prevY, int screenX)
        {
            int platform = 0;

            //  check which platform is the previous one in the array
            for(int i = 0; i < locY.Count(); i++)
            {
                if(prevY == locY[i])
                {
                    platform = i;
                    break;
                }
            }

            //  randomly choose the next platform based on the previous one
            Random rgen = new Random();
            int nextY = rgen.Next(0, platform + 1);

            //  return the next platform location
            Rectangle rec = new Rectangle(screenX + 500, nextY, 200, 100);
            return rec;
        }

        /// <summary>
        /// this method will set the first few platforms up, then platformLoc will take over
        /// </summary>
        public Rectangle platformInitial(int prevY, int prevX)
        {
            Rectangle rec;
            int platform = 0;

                //  check which platform is the previous one in the array
                for (int i = 0; i < locY.Count(); i++)
                {
                    if (prevY == locY[i])
                    {
                        platform = i;
                        break;
                    }
                }
                //  randomly choose the next platform based on the previous one
                Random rgen = new Random();
                int nextY = rgen.Next(0, platform + 1);

                rec = new Rectangle(prevX, nextY, 200, 100);
            
            return rec;
        }


    }
}
