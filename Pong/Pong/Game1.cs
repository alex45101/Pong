using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Xml;
using System.IO;
using Glib.XNA.SpriteLib;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Menu menu;
        GameEngine gameengine;

        Song song;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            IsMouseVisible = true;

            gameengine = new GameEngine();
            menu = new Menu(gameengine);
            base.Initialize();
        }

        bool useCustomTexture = false;
        Texture2D customTexture = null;

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            if (useCustomTexture)
            {
                customTexture = Texture2D.FromStream(GraphicsDevice, custStream);
            }
            song = Content.Load<Song>("Call to Adventure");
            Sprite s = new Sprite(Content.Load<Texture2D>("PongCircle"), new Vector2(370, 180), spriteBatch);
            s.UpdateParams = new UpdateParamaters(true, true, true);
            Sprite p1 = new Sprite(useCustomTexture ? customTexture : Content.Load<Texture2D>("PongSprite1"), new Vector2(0, 160), spriteBatch);
            p1.Scale = useCustomTexture ? new Vector2(80f / customTexture.Width, 80f / customTexture.Height) : new Vector2(1);
            Sprite p2 = new Sprite(Content.Load<Texture2D>("PongSprite2"), new Vector2(720, 160), spriteBatch);

            s.Updated += new EventHandler(s_Updated);
            p1.Updated += new EventHandler(p1_Updated);
            p2.Updated += new EventHandler(p2_Updated);

            if (MediaPlayer.State != MediaState.Playing)
            {
                MediaPlayer.Play(song);
            }

            //sm = new SpriteManager(spriteBatch, logo, play, playhighlite, singleplayer, singleplayerhighlite);

            menu.Load(spriteBatch, Content);
            gameengine.Load(spriteBatch, Content, graphics.GraphicsDevice.Viewport, useCustomTexture, customTexture);
            // TODO: use this.Content to load your game content here
        }


        SpriteManager sm;

        KeyboardState keyboard = Keyboard.GetState();

        void logo_Updated(object source, EventArgs e)
        { 
        
        }

        void s_Updated(object source, EventArgs e)
        {
            keyboard = Keyboard.GetState();
            Keys[] pressedKeys = keyboard.GetPressedKeys();

            if (pressedKeys.Contains(Keys.Space))
            {
                ((Sprite)source).XSpeed = -10;
                ((Sprite)source).YSpeed = 5f;    
            }

            Rectangle paddle1 = new Rectangle(Convert.ToInt32(sm.Sprites[1].Position.X), Convert.ToInt32(sm.Sprites[1].Position.Y), Convert.ToInt32(sm.Sprites[1].Width), Convert.ToInt32(sm.Sprites[1].Height));

            Rectangle paddle2 = new Rectangle(Convert.ToInt32(sm.Sprites[2].Position.X), Convert.ToInt32(sm.Sprites[2].Position.Y), Convert.ToInt32(sm.Sprites[2].Width), Convert.ToInt32(sm.Sprites[2].Height));

            Rectangle ball = new Rectangle(Convert.ToInt32(sm.Sprites[0].Position.X), Convert.ToInt32(sm.Sprites[0].Position.Y), Convert.ToInt32(sm.Sprites[0].Width), Convert.ToInt32(sm.Sprites[0].Height));

            if(ball.Y + ball.Height >= graphics.GraphicsDevice.Viewport.Height || ball.Y <= 0)
            {
                ((Sprite)source).YSpeed *= -1;
            }

            if (paddle1.Intersects(ball) || paddle2.Intersects(ball))
            {
                ((Sprite)source).XSpeed *= -1;
            }

            if (ball.X < 0)
            {
                //set X and Y to the center, speed is 0;
               /*while (elapsedTime < resetTimer)
                {
                    //add elapsedtime by the gametimes timer
                }*/
                //speed is back to normal
            }
        }

        string username;

        public void signInAs(string username)
        {
            this.username = username;
        }

        Stream custStream = null;

        public void setSteveIcon(Stream imageIco)
        {
            useCustomTexture = true;
            custStream = imageIco;
        }

        void p1_Updated(object source, EventArgs e)
        {

            Rectangle paddle1 = new Rectangle(Convert.ToInt32(sm.Sprites[1].Position.X), Convert.ToInt32(sm.Sprites[1].Position.Y), Convert.ToInt32(sm.Sprites[1].Width), Convert.ToInt32(sm.Sprites[1].Height));

            Keys[] pressedKeys = keyboard.GetPressedKeys();
            //first player go up
            if (pressedKeys.Contains(Keys.W))
            {
                ((Sprite)source).Y -= 15;
            }
            //first player go down
            if (pressedKeys.Contains(Keys.S))
            {
                ((Sprite)source).Y += 15;
            }

            if (paddle1.Y + paddle1.Height > graphics.GraphicsDevice.Viewport.Height)
            {
                ((Sprite)source).Y = graphics.GraphicsDevice.Viewport.Height - paddle1.Height - 1;
            }
            if (paddle1.Y < 0)
            {
                ((Sprite)source).Y = 1;
            }
        }

        void p2_Updated(object source, EventArgs e)
        {


            Rectangle paddle2 = new Rectangle(Convert.ToInt32(sm.Sprites[2].Position.X), Convert.ToInt32(sm.Sprites[2].Position.Y), Convert.ToInt32(sm.Sprites[2].Width), Convert.ToInt32(sm.Sprites[2].Height));

            Keys[] pressedKeys = keyboard.GetPressedKeys();
            //second player go up
            if (pressedKeys.Contains(Keys.Up))
            {
                ((Sprite)source).Y -= 15;
            }
            //second player go down
            if (pressedKeys.Contains(Keys.Down))
            {
                ((Sprite)source).Y += 15;
            }

            if (paddle2.Y + paddle2.Height > graphics.GraphicsDevice.Viewport.Height)
            {
                ((Sprite)source).Y = graphics.GraphicsDevice.Viewport.Height - paddle2.Height - 1;
            }
            if (paddle2.Y < 0)
            {
                ((Sprite)source).Y = 1;
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            


            if (!menu.IsGameStart)
            {
                menu.Update(gameTime);
            }
            else
            {
                gameengine.IsMultiPlayer = menu.IsMultiPlayer;
                gameengine.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here
            
            //sm.Draw();

            if (!menu.IsGameStart)
            {
                menu.Draw();
            }
            else
            {
                gameengine.Draw(gameTime, spriteBatch);
            }

            base.Draw(gameTime);
        }
    }
}
