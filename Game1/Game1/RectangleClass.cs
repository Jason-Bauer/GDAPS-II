using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class RectangleClass
    {
        //  fields
        public Rectangle position;
        public Texture2D sprite;
        public int X;
        public int Y;
        public int Width;
        public int Height;

        //  properties
        public Rectangle Position
        {
            get { return position; }
            set
            {
                position = value;
            }
        }
        public Texture2D Sprite
        {
            get { return sprite; }
            set
            {
                sprite = value;
            }
        }

        //  constructor
        public RectangleClass(int x, int y, int width, int height)
        {
            position = new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// Draws the rectangle to the screen
        /// </summary>
        /// <param name="a">spriteBatch used to draw the rectangle</param>
        public virtual void Draw(SpriteBatch a)
        {
            a.Draw(Sprite, position, Color.Beige);
        }
    }
}
