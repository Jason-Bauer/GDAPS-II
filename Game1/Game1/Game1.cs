using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
       
        
       
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Texture2D player;
        public Texture2D Platform;
        player you = new player(175, 150, 50, 50);
        Rectangle platformplace = new Rectangle(150, 250, 200, 100);
        Rectangle platformplace2 = new Rectangle(450, 250, 200, 10);
        
       
   

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        public void ProcessInput()
        {
            KeyboardState keys = Keyboard.GetState();
            if (keys.IsKeyDown(Keys.S))
            {
                you.position.Y = you.position.Y + 5;
            }
            if (keys.IsKeyDown(Keys.A))
            {
                you.position.X = you.position.X - 5;
            }
            if (keys.IsKeyDown(Keys.D))
            {
                you.position.X = you.position.X + 5;
            }
            if (keys.IsKeyDown(Keys.W))
            {
                you.position.Y = you.position.Y - 5;
            }
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            
            // TODO: Add your initialization logic here
            you.jumping = true;
            
          
        
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            you.sprite = Content.Load<Texture2D>("illuminati.png");
            Platform = Content.Load<Texture2D>("square.png");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
           
            ProcessInput();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            you.jumpcheck();

            if (you.position.Intersects(platformplace) || you.position.Intersects(platformplace2))
            {
                you.jumping = false;
                you.position.Y = platformplace.Y - 50;
            }
            else { you.jumping = true; }

            if (you.position.Y >= GraphicsDevice.Viewport.Height) { you.position.Y = 0; }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();

            you.Draw(spriteBatch);
            spriteBatch.Draw(Platform, platformplace, Color.AliceBlue);
            spriteBatch.Draw(Platform, platformplace2, Color.AliceBlue);

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
