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
        public Rectangle position;
        public Texture2D sprite;
        public int X;
        public int Y;
        public int Width;
        public int Height;

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






        public RectangleClass(int x, int y, int width, int height)
        {
            position = new Rectangle(x, y, width, height);
        }


        public virtual void Draw(SpriteBatch a)
        {
            a.Draw(Sprite, position, Color.Beige);
        }
    }
}
