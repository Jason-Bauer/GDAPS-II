using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Game1
{
    class Enemy
    {
        //  fields
        Random rng = new Random();
        public int timetilspawn;
        public Rectangle hitbox;
        public Texture2D sprite;
        public int counter = 0;

        //  constructor
        public Enemy(int Y,int width,int height) 
        {
            hitbox = new Rectangle(800, Y, width, height);
            timetilspawn= rng.Next(100, 300);

        }
    }
}
