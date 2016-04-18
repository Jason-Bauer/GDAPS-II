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
       
        enum GameState // enum for different game states
        {
            Start,
            inGame,
            Options,
            Pause,
            gameOver
        }
        
        Random rnd = new Random();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public Texture2D player;
        public Texture2D Platform;
        Player you;     //  the player object
        KeyboardState prevKBState;
        KeyboardState keys;
        SpriteFont spriteFont;
        GameState state;
        Enemy A;
        Enemy B;
        bool Lazoron = false;
        Rectangle projectile;
        GameState prevState = GameState.Start;
        Vector2 textLoc = new Vector2(100, 100);
        int score = 0;
        
        //  declare platforms
        Platform platform1;
        Platform platform2;
        Platform platform3;
        Platform platform4;

        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        public void ProcessInput()
        {
            keys = Keyboard.GetState();
//            if (keys.IsKeyDown(Keys.S))
//            {
//                you.position.Y = you.position.Y + 5;
//            }
            if (keys.IsKeyDown(Keys.A))
            {
                you.position.X = you.position.X - 6;
            }
            if (keys.IsKeyDown(Keys.D))
            {
                you.position.X = you.position.X + 6;
            }
//            if (keys.IsKeyDown(Keys.W))
//            {
//                you.position.Y = you.position.Y - 5;
//            }
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
            //  Initialize player attributes
            you = new Player(175, 0, 50, 50);
            you.jumping = true;

            //  initialize enemies
            A = new Enemy(rnd.Next(100,GraphicsDevice.Viewport.Height - 150),50, 50);
            B= new Enemy(rnd.Next(100,GraphicsDevice.Viewport.Height - 150),50, 50);

            //  initialize platforms
             platform1 = new Platform(100, 200, rnd.Next(125,200), 50);
             platform2 = new Platform(350, 100, rnd.Next(125, 200), 50);
             platform3 = new Platform(600, 400, rnd.Next(125, 200), 50);
             platform4 = new Platform(800, 300, rnd.Next(125, 200), 50);

             platform1 = new Platform(100, 200, 200, 50);
             platform2 = new Platform(300, 100, 200, 50);
             platform3 = new Platform(500, 400, 200, 50);
             platform4 = new Platform(700, 300, 200, 50);

           //   initialize game state
            state = new GameState();

            //  initialize keyboard state
            keys = Keyboard.GetState();
            prevKBState = keys;

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
            A.sprite = Content.Load<Texture2D>("illuminati.png");
            B.sprite = Content.Load<Texture2D>("illuminati.png");
            you.sprite = Content.Load<Texture2D>("illuminati.png");
            Platform = Content.Load<Texture2D>("square.png");
            spriteFont = Content.Load<SpriteFont>("Tahoma_40");

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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
               Environment.Exit(0);

            //  get keyboard state
            keys = Keyboard.GetState();
            
            // Game state switch statement
            switch (state)
            {
                case GameState.Start:
                    
                        if (prevKBState.IsKeyUp(Keys.Enter) && keys.IsKeyDown(Keys.Enter))
                        {
                            state = GameState.inGame;
                        }
                        else if (prevKBState.IsKeyUp(Keys.O) && keys.IsKeyDown(Keys.O))
                        {
                            state = GameState.Options;
                            prevState = GameState.Start;
                        }
                        prevKBState = keys;
                        keys = Keyboard.GetState();
                        break;
                     // END OF START

                case GameState.inGame:
                    score++;
                        ProcessInput();
                        you.jumpcheck();
                        A.hitbox.X -= 5;
                        B.hitbox.X -= 6;
                        platform1.X -= 4;
                        platform2.X -= 4;
                        platform3.X -= 4;
                        platform4.X -= 4;
                        platform1.platform.X -= 4;
                        platform2.platform.X -= 4;
                        platform3.platform.X -= 4;
                        platform4.platform.X -= 4;

                        // change state to Pause  Menu
                        if (prevKBState.IsKeyUp(Keys.P) && keys.IsKeyDown(Keys.P))
                        {
                            state = GameState.Pause;
                        }

                        //  Enemies
                        if (A.hitbox.X <= -200)
                        {
                            A.counter++;
                            if (A.counter >= A.timetilspawn) 
                            {
                                A.counter = 0;
                                A.timetilspawn = rnd.Next(100,300);
                                A.hitbox.X = 800;
                                A.hitbox.Y += rnd.Next(150);
                                if (A.hitbox.Y >= GraphicsDevice.Viewport.Height-150) 
                                {
                                    A.hitbox.Y = rnd.Next(GraphicsDevice.Viewport.Height-150); 
                                }
                            }

                            
                        }
                        if (B.hitbox.X <= -200)
                        {
                            B.counter++;
                            if (B.counter >= B.timetilspawn)
                            {
                                B.counter = 100;
                                B.timetilspawn = rnd.Next(100, 300);
                                B.hitbox.X = 800;
                                B.hitbox.Y += rnd.Next(150);
                                if (B.hitbox.Y >= GraphicsDevice.Viewport.Height - 150)
                                {
                                    B.hitbox.Y = rnd.Next(GraphicsDevice.Viewport.Height - 150);
                                }
                            }


                        }
                   
                        //  Platforms
                        if (platform1.X <= -200)
                        {
                            platform1.platform.Width = rnd.Next(125, 200);
                            platform1.platform.X = 800;
                            platform1.X = 800;
                            platform1.platform.Y -= rnd.Next(100);
                            platform1.platform.Y += rnd.Next(100);
                        }

                        if (platform2.X <= -200)
                        {
                            platform2.platform.Width = rnd.Next(125, 200);
                            platform2.platform.X = 800;
                            platform2.X = 800;
                            platform2.platform.Y -= rnd.Next(100);
                            platform2.platform.Y += rnd.Next(150);
                        }

                        if (platform3.X <= -200)
                        {
                            platform3.platform.Width = rnd.Next(125, 200);
                            platform3.platform.X = 800;
                            platform3.X = 800;
                            platform3.platform.Y -= rnd.Next(200);
                            platform3.platform.Y += rnd.Next(200);
                        }

                        if (platform4.X <= -200)
                        {
                            platform4.platform.Width = rnd.Next(125, 200);
                            platform4.platform.X = 800;
                            platform4.X = 800;
                            platform4.platform.Y -= rnd.Next(150);
                            platform4.platform.Y += rnd.Next(150);

                        }

                    if (platform1.platform.Y <=100)
                        {
                            platform1.platform.Y = rnd.Next( 100,GraphicsDevice.Viewport.Height - 50);
                            platform1.Y = platform1.platform.Y; 
                        }

                    if (platform2.platform.Y <= 100)
                    {
                        platform2.platform.Y = rnd.Next(100, GraphicsDevice.Viewport.Height - 50);
                        platform2.Y = platform2.platform.Y; 
                    }
                    if (platform3.platform.Y <= 100)
                    {
                        platform3.platform.Y = rnd.Next( 100,GraphicsDevice.Viewport.Height - 50);
                        platform3.Y = platform3.platform.Y; 
                    }
                    if (platform4.platform.Y <= 100)
                    {
                        platform4.platform.Y = rnd.Next(100, GraphicsDevice.Viewport.Height - 50);
                        platform4.Y = platform4.platform.Y; 
                    }

                    if (platform1.platform.Y >= GraphicsDevice.Viewport.Height - 99)
                    {
                         
                        platform1.platform.Y = rnd.Next( GraphicsDevice.Viewport.Height - 50);
                        platform1.Y = platform1.platform.Y;
                    }
                    if (platform2.platform.Y >= GraphicsDevice.Viewport.Height - 99)
                    {
                        platform2.platform.Y = rnd.Next( GraphicsDevice.Viewport.Height - 50);
                        platform2.Y = platform2.platform.Y; 
                    }
                    if (platform3.platform.Y >= GraphicsDevice.Viewport.Height - 99)
                    {
                        platform3.platform.Y = rnd.Next( GraphicsDevice.Viewport.Height - 50);
                        platform3.Y = platform3.platform.Y; 
                    }
                    if (platform4.platform.Y >= GraphicsDevice.Viewport.Height - 99)
                    {
                        platform4.platform.Y = rnd.Next( GraphicsDevice.Viewport.Height - 50);
                        platform4.Y = platform4.platform.Y; 
                    }
                    if (you.Position.Intersects(A.hitbox)) { state = GameState.gameOver; }
                    if (you.Position.Intersects(B.hitbox)) { state = GameState.gameOver; }


                    //  laser intersecting enemies
                    if (Lazoron) 
                    {
                        if (A.hitbox.Intersects(projectile))
                        {
                            //  move enemy off screen
                            score += 100;
                            A.hitbox.X = -400;
                        }
                        if (B.hitbox.Intersects(projectile))
                        {
                            //  move enemy off screen 
                            score += 100;
                            B.hitbox.X = -400;
                        }
                    }
                    //  END OF LASER COLLISIONS
                        
                    
                    
                        //  check for collision between player and objects
                        if(you.Position.Intersects(platform1.platform))
                        {
                            //  check if player is above the platform, okay to get on platform
                            if(you.position.Bottom - 10 <= platform1.platform.Bottom)
                            {
                                //  if the player was falling, allow the player to stand on it
                                if(you.Jumpspeed > 0)
                                {
                                    //  move player on top of the platform
                                    you.position.Y = platform1.platform.Top - you.position.Height;
                                    //  set jumping to false
                                    you.jumping = false;
                                you.Jumpspeed = 0;
                                    you.jumpcheck();
                                }
                                //  else the player still has an upward momentum, so let them keep going    
                                else
                                {
                                    you.jumping = true;
                                    you.jumpcheck();
                                }
                            }
                            else
                            {
                               you.jumping = true;
                               you.jumpcheck();
                            }
                        }
                        else if (you.Position.Intersects(platform2.platform))
                        {

                        //  check if player is above the platform, okay to get on platform
                        if (you.position.Bottom - 10 <= platform2.platform.Bottom)
                        {
                            //  if the player was falling, allow the player to stand on it
                            if (you.Jumpspeed > 0)
                            {
                                //  move player on top of the platform
                                you.position.Y = platform2.platform.Top - you.position.Height;
                                //  set jumping to false
                                you.jumping = false;
                                you.Jumpspeed = 0;
                                you.jumpcheck();
                            }
                            //  else the player still has an upward momentum, so let them keep going    
                            else if (you.Jumpspeed <= 0)
                            {
                                you.jumping = true;
                                you.jumpcheck();
                            }
                        }
                        else
                        {
                            you.jumping = true;
                            you.jumpcheck();
                        }

                    }
                        else if (you.Position.Intersects(platform3.platform))  //  !!!!!!!!!!!!!!!!!!!!!!!!!change to use platforms from the platform class later!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        {

                        //  check if player is above the platform, okay to get on platform
                        if (you.position.Bottom - 10 <= platform3.platform.Bottom)
                        {
                            //  if the player was falling, allow the player to stand on it
                            if (you.Jumpspeed > 0)
                            {
                                //  move player on top of the platform
                                you.position.Y = platform3.platform.Top - you.position.Height;
                                //  set jumping to false
                                you.jumping = false;
                                you.Jumpspeed = 0;
                                you.jumpcheck();
                            }
                            //  else the player still has an upward momentum, so let them keep going    
                            else if (you.Jumpspeed <= 0)
                            {
                                you.jumping = true;
                                you.jumpcheck();
                            }
                        }
                        else
                        {
                            you.jumping = true;
                            you.jumpcheck();
                        }
                    }
                        else if (you.Position.Intersects(platform4.platform))   
                        {

                        //  check if player is above the platform, okay to get on platform
                        if (you.position.Bottom - 15 <= platform4.platform.Bottom)
                        {
                            //  if the player was falling, allow the player to stand on it
                            if (you.Jumpspeed > 0)
                            {
                                //  move player on top of the platform
                                you.position.Y = platform4.platform.Top - you.position.Height;
                                //  set jumping to false
                                you.jumping = false;
                                you.Jumpspeed = 0;
                                you.jumpcheck();
                            }
                            //  else the player still has an upward momentum, so let them keep going    
                            else if (you.Jumpspeed <= 0)
                            {
                                you.jumping = true;
                                you.jumpcheck();
                            }
                        }
                        else
                        {
                            you.jumping = true;
                            you.jumpcheck();
                        }
                    }

                        else
                        {
                            you.jumping = true;
                            you.jumpcheck();
                        }
                        //  END OF PLAYER PLATFORM COLLISIONS

                    //  check if laser has been fired
                        if (prevKBState.IsKeyUp(Keys.Enter) && keys.IsKeyDown(Keys.Enter))
                        {
                            Lazoron = true;
                        }
                        else 
                        { 
                            Lazoron = false;
                        }
                    //  END OF LASER CHECK

                        prevKBState = keys;
                        keys = Keyboard.GetState();

                          //if player falls off the bottom, he dies
                          if (you.position.Y >= GraphicsDevice.Viewport.Height)
                          {
                            state = GameState.gameOver;
                          }

                        //    get Keyboard states
                        prevKBState = keys;
                        keys = Keyboard.GetState();

                        break;
                    // END OF IN-GAME STATE
                    
                case GameState.Pause:
                    
                        if (prevKBState.IsKeyUp(Keys.P) && keys.IsKeyDown(Keys.P))
                        {
                            state = GameState.inGame;
                        }
                        else if (prevKBState.IsKeyUp(Keys.M) && keys.IsKeyDown(Keys.M))
                        {
                        //  reset game
                        you.position.X = 175; // return the player to his original position
                        you.position.Y = 0;
                        Initialize();

                        state = GameState.Start;
                        }
                        else if (prevKBState.IsKeyUp(Keys.O) && keys.IsKeyDown(Keys.O))
                        {
                            state = GameState.Options;
                            prevState = GameState.Pause;
                        }
                        prevKBState = keys;
                        keys = Keyboard.GetState();
                        break;
                     // END OF PAUSE

                case GameState.Options:
                    
                        if (prevKBState.IsKeyUp(Keys.O) && keys.IsKeyDown(Keys.O))
                        {
                            if (prevState == GameState.Start)
                            {
                                state = GameState.Start;
                            }
                            else if (prevState == GameState.Pause)
                            {
                                state = GameState.Pause;
                            }
                        }
                        prevKBState = keys;
                        keys = Keyboard.GetState();
                        break;
                     // END OF OPTIONS

                case GameState.gameOver:
                    
                        prevKBState = keys;
                        keys = Keyboard.GetState();

                        if (keys.IsKeyDown(Keys.Enter))
                        {
                            you.position.X = 175; // return the player to his original position
                            you.position.Y = 0;
                            Initialize();

                            
                            state = GameState.Start; 

                        }
                        break;
                     // END OF GAME OVER
                    
            } // END OF SWITCH STATEMENT

           
            projectile=new Rectangle(you.position.X+3,you.position.Y+10 ,900,10);
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


            switch (state)
            {
                case GameState.Start:
                    {
                        spriteBatch.DrawString(spriteFont, "Super Robo W.H.A.L.E. \nPress 'Enter' to start \nPress 'O' for Options", textLoc, Color.Crimson);
                        break;
                    }// END OF START MENU
                case GameState.inGame:
                    {
                        you.Draw(spriteBatch);
                        //spriteBatch.Draw(Platform, platformplace, Color.AliceBlue);
                        //spriteBatch.Draw(Platform, platformplace2, Color.AliceBlue);
                        //  Draw platforms
                        spriteBatch.DrawString(spriteFont, "Your score is " + score, new Vector2(10, 10), Color.White);
                        spriteBatch.Draw(Platform, platform1.platform, Color.White);
                            spriteBatch.Draw(Platform, platform2.platform, Color.White);
                            spriteBatch.Draw(Platform, platform3.platform, Color.White);
                            spriteBatch.Draw(Platform, platform4.platform, Color.White);
                            spriteBatch.Draw(A.sprite, A.hitbox, Color.White);
                            spriteBatch.Draw(B.sprite, B.hitbox, Color.White);
                            //  Draw player
                            you.Draw(spriteBatch);
                            if (Lazoron) 
                            {
                                spriteBatch.Draw(you.sprite, projectile, Color.White);
                            }
                        break;
                    }//END OF IN-GAME
                case GameState.Options:
                    {
                        if (prevState != GameState.Start)
                        {
                            spriteBatch.DrawString(spriteFont, "Your score is " + score, new Vector2(10, 10), Color.White);
                            spriteBatch.Draw(Platform, platform1.platform, Color.White);
                            spriteBatch.Draw(Platform, platform2.platform, Color.White);
                            spriteBatch.Draw(Platform, platform3.platform, Color.White);
                            spriteBatch.Draw(Platform, platform4.platform, Color.White);
                            spriteBatch.Draw(A.sprite, A.hitbox, Color.White);
                            spriteBatch.Draw(B.sprite, B.hitbox, Color.White);

                            you.Draw(spriteBatch);
                        }
                        spriteBatch.DrawString(spriteFont, "OPTIONS \n(of which you have none) \nPress 'O' to return", textLoc, Color.Crimson);
                        break;
                    }//END OG OPTIONS MENU
                case GameState.Pause:
                    {
                        spriteBatch.DrawString(spriteFont, "Your score is " + score, new Vector2(10, 10), Color.White);
                        spriteBatch.Draw(Platform, platform1.platform, Color.White);
                        spriteBatch.Draw(Platform, platform2.platform, Color.White);
                        spriteBatch.Draw(Platform, platform3.platform, Color.White);
                        spriteBatch.Draw(Platform, platform4.platform, Color.White);
                        spriteBatch.Draw(A.sprite, A.hitbox, Color.White);
                        spriteBatch.Draw(B.sprite, B.hitbox, Color.White);

                        you.Draw(spriteBatch);
                        spriteBatch.DrawString(spriteFont, "Pause\n'P' to resume game\n'O' for Options \n'M' to return to Start Menu", textLoc, Color.Crimson);
                        break;
                    }//END OF PAUSE MENU
                case GameState.gameOver:
                    {
                        spriteBatch.DrawString(spriteFont, "You tried. \n...(loser.)", textLoc, Color.DarkMagenta);
                        break;
                    }//END OF GAME OVER MENU
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
