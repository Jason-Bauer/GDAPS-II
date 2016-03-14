using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Game1
{
    // enum for GameStates
    enum GameState
    {
        Start,
        Game,
        Options,
        Pause,
        GameOver
    }


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
        GameState state;
        SpriteFont font; // placeholder font
        KeyboardState prevKBState;
        KeyboardState kbState;
        Vector2 vector;



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
            
            you.jumping = true;
            state = new GameState();
            kbState = Keyboard.GetState();
            prevKBState = kbState;
            vector = new Vector2(100, 100);

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
            font = Content.Load<SpriteFont>("Consolas_16");

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            prevKBState = kbState;
            kbState = Keyboard.GetState();

            GameState prevState = GameState.Start;

          switch(state)
            {
                case GameState.Start:
                    {
                        if(prevKBState.IsKeyUp(Keys.Enter) && kbState.IsKeyDown(Keys.Enter))
                        {
                            state = GameState.Game;
                        }
                        else if(prevKBState.IsKeyUp(Keys.O) && kbState.IsKeyDown(Keys.O))
                        {
                            state = GameState.Options;
                            prevState = GameState.Start;
                        }
                        prevKBState = kbState;
                        kbState = Keyboard.GetState();
                        break;
                    } // end of Start

                case GameState.Game:
                    {
                        ProcessInput();
                        you.jumpcheck();

                        if (you.position.Intersects(platformplace) || you.position.Intersects(platformplace2))
                        {
                            you.jumping = false;
                            you.position.Y = platformplace.Y - 50;
                        }
                        else { you.jumping = true; }

                        if (you.position.Y >= GraphicsDevice.Viewport.Height) { you.position.Y = 0; }
                        
                        // change state to Options Menu
                        if(prevKBState.IsKeyUp(Keys.P) && kbState.IsKeyDown(Keys.P))
                        {
                            state = GameState.Pause;
                        }
                        prevKBState = kbState;
                        kbState = Keyboard.GetState();
                        break;
                    } // end of Game

                case GameState.Pause:
                    {
                        if(prevKBState.IsKeyUp(Keys.P) && kbState.IsKeyDown(Keys.P))
                        {
                            state = GameState.Game;
                        }
                        else if(prevKBState.IsKeyUp(Keys.M) && kbState.IsKeyDown(Keys.M))
                        {
                            state = GameState.Start;
                        }
                        else if(prevKBState.IsKeyUp(Keys.O) && kbState.IsKeyDown(Keys.O))
                        {
                            state = GameState.Options;
                            prevState = GameState.Pause;
                        }
                        prevKBState = kbState;
                        kbState = Keyboard.GetState();
                        break;
                    } // end of Pause

                case GameState.Options:
                    {
                        if(prevKBState.IsKeyUp(Keys.O) && kbState.IsKeyDown(Keys.O))
                        {
                            if(prevState == GameState.Start)
                            {
                                state = GameState.Start;
                            }
                            else if(prevState == GameState.Pause)
                            {
                                state = GameState.Pause;
                            }    
                        }
                        prevKBState = kbState;
                        kbState = Keyboard.GetState();
                        break;
                    } // end of Options

                case GameState.GameOver:
                    {
                        prevKBState = kbState;
                        kbState = Keyboard.GetState();
                        break;
                    } // end of GameOver
            }

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
            switch(state)
            {
                case GameState.Start:
                    {
                        spriteBatch.DrawString(font, "Super Robo W.H.A.L.E. \nPress 'Enter' to start \nPress 'O' for Options", vector, Color.Crimson);
                        break;
                    }
                case GameState.Game:
                    {
                        you.Draw(spriteBatch);
                        spriteBatch.Draw(Platform, platformplace, Color.AliceBlue);
                        spriteBatch.Draw(Platform, platformplace2, Color.AliceBlue);
                        break;
                    }
                case GameState.Options:
                    {
                        spriteBatch.DrawString(font, "OPTIONS \n(of which you have none) \nPress 'O' to return", vector, Color.Crimson);
                        break;
                    }
                case GameState.Pause:
                    {
                        spriteBatch.DrawString(font, "Pause\n'P' to resume game\n'O' for Options \n'M' to return to Start Menu", vector, Color.Crimson);
                        break;
                    }
                case GameState.GameOver:
                    {
                        spriteBatch.DrawString(font, "You tried. \n...loser.", vector, Color.Bisque);
                        break;
                    }
            }
            
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
