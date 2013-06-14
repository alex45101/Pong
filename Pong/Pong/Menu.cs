using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Glib.XNA.SpriteLib;
using Glib.XNA;

namespace Pong
{
    public class Menu
    {

        private bool _isGameStart = false;

        public bool IsGameStart
        {
            get
            {
                return _isGameStart;
            }
        }

        private bool _isMultiPlayer = false;

        public bool IsMultiPlayer
        {
            get
            {
                return _isMultiPlayer;
            }
        }

        private SpriteManager spriteManager;
        private GameEngine _engine;


        public Menu(GameEngine engine)
        {
            _engine = engine;
            _isGameStart = false;
        }

        SpriteFont font;
        string text;
        Vector2 location;
        TextSprite stan;
        TextSprite easy;
        TextSprite medium;

        public void Load(SpriteBatch spriteBatch, ContentManager Content)
        {
            sb = spriteBatch;
            Sprite logo = new SpriteFactory(Content.Load<Texture2D>("minecraft-text"), new Vector2(210, 5), spriteBatch).SetScale(new Vector2(0.2f, 0.2f)).Build();
            logo.UseCenterAsOrigin = false;
            Sprite singleplayer = new Sprite(Content.Load<Texture2D>("singleplayer"), new Vector2(340, 150), null);
            Sprite singleplayerhighlite = new SpriteFactory(Content.Load<Texture2D>("singleplayerhighlite"), new Vector2(340, 150), spriteBatch).SetScale(new Vector2(0f)).Build();
            Sprite multiplayer = new Sprite(Content.Load<Texture2D>("multiplayer"), new Vector2(270, 220), null);
            Sprite multiplayerhighlite = new Sprite(Content.Load<Texture2D>("multiplayerhighlite"), new Vector2(270, 220), null);
            Sprite options = new Sprite(Content.Load<Texture2D>("Options"), new Vector2(325, 310), null);
            Sprite optionsHighLite = new Sprite(Content.Load<Texture2D>("OptionsHighLite"), new Vector2(325, 310), null);
            Sprite controls = new Sprite(Content.Load<Texture2D>("Controls"), new Vector2(340, 150), null);

            stan = new TextSprite(spriteBatch, new Vector2(170, 220), Content.Load<SpriteFont>("SpriteFont1"), "Stan",  Color.Black);
            stan.Color = Color.Transparent;

            easy = new TextSprite(spriteBatch, new Vector2(250, 220), Content.Load<SpriteFont>("SpriteFont1"), "Easy", Color.Black);
            easy.Color = Color.Transparent;

            medium = new TextSprite(spriteBatch, new Vector2(330, 220), Content.Load<SpriteFont>("SpriteFont1"), "Medium", Color.Black);
            medium.Color = Color.Transparent;

            controls.Scale = new Vector2(0);
            Sprite controlsHighLite = new Sprite(Content.Load<Texture2D>("ControlsHighLite"), new Vector2(340, 150), null);
            controlsHighLite.Scale = new Vector2(0);
            font = Content.Load<SpriteFont>("SpriteFont1");
            location = new Vector2();
            spriteManager = new SpriteManager(spriteBatch, /*0*/logo, /*1*/singleplayer, /*2*/singleplayerhighlite, /*3*/multiplayer, /*4*/multiplayerhighlite, /*5*/options, /*6*/optionsHighLite, /*7*/controls, /*8*/controlsHighLite);

            multiplayer.Updated += new EventHandler(multiplayer_Updated);
            singleplayer.Updated += new EventHandler(singleplayer_Updated);
            options.Updated += new EventHandler(options_Updated);
            controls.Updated += new EventHandler(controls_Updated);
            easy.Updated += new EventHandler(easy_Updated);
            stan.Updated += new EventHandler(stan_Updated);
            medium.Updated += new EventHandler(medium_Updated);
        }

        //difficulty level medium
        void medium_Updated(object sender, EventArgs e)
        {
            TextSprite spr = (TextSprite)sender;
            MouseState mouse = Mouse.GetState();

            if (medium.Color != Color.Transparent)
            {
                if (mouse.X > medium.X && mouse.X < medium.X + medium.Width && mouse.Y > medium.Y && mouse.Y < medium.Y + medium.Height)
                {
                    medium.Color = Color.Gold;
                }
                else
                {
                    medium.Color = Color.Black;
                }
            }

            if (mouse.X > spr.X && mouse.X < spr.X + spr.Width && mouse.Y > spr.Y && mouse.Y < spr.Y + spr.Height && mouse.LeftButton == ButtonState.Pressed)
            {
                _isMultiPlayer = false;
                _isGameStart = true;
                _engine.aiLevel = 2;

            }
        }


        void controls_Updated(object source, EventArgs e)
        {
            MouseState mouse = Mouse.GetState();
            Sprite spr = (Sprite)source;
            if (mouse.X > spr.X && mouse.X < spr.X + spr.Width && mouse.Y > spr.Y && mouse.Y < spr.Y + spr.Height)
            {
                spriteManager.Sprites[8].Scale = new Vector2(1, 1);
            }
            else
            {
                spriteManager.Sprites[8].Scale = new Vector2(0, 0);
            }
        }

        void options_Updated(object source, EventArgs e)
        {
            MouseState mouse = Mouse.GetState();
            Sprite spr = (Sprite)source;
            if (mouse.X > spr.X && mouse.X < spr.X + spr.Width && mouse.Y > spr.Y && mouse.Y < spr.Y + spr.Height)
            {
                spriteManager.Sprites[6].Scale = new Vector2(1, 1);
            }
            else
            {
                spriteManager.Sprites[6].Scale = new Vector2(0, 0);
            }
            if (mouse.X > spr.X && mouse.X < spr.X + spr.Width && mouse.Y > spr.Y && mouse.Y < spr.Y + spr.Height && mouse.LeftButton == ButtonState.Pressed)
            {
                spriteManager.Sprites[1].Scale = new Vector2(0, 0);
                spriteManager.Sprites[3].Scale = new Vector2(0, 0);
                spriteManager.Sprites[5].Scale = new Vector2(0, 0);

                spriteManager.Sprites[7].Scale = new Vector2(1, 1);
            }
        }

        public void Update(GameTime gameTime)
        {
            spriteManager.Update();
            stan.Update();
            easy.Update();
            medium.Update();
        }

        SpriteBatch sb;

        public void Draw()
        {
            sb.Begin();
            spriteManager.DrawNonAuto();
            stan.Draw();
            easy.Draw();
            medium.Draw();
            sb.End();
        }

        private void multiplayer_Updated(object source, EventArgs e)
        {
            MouseState mouse = Mouse.GetState();
            Sprite spr = (Sprite)source;
            if (mouse.X > spr.X && mouse.X < spr.X + spr.Width && mouse.Y > spr.Y && mouse.Y < spr.Y + spr.Height)
            {
                spriteManager[4].Scale = new Vector2(1, 1);
            }
            else
            {
                spriteManager[4].Scale = new Vector2(0, 0);
            }

            if (mouse.X > spr.X && mouse.X < spr.X + spr.Width && mouse.Y > spr.Y && mouse.Y < spr.Y + spr.Height && mouse.LeftButton == ButtonState.Pressed)
            {
                _isMultiPlayer = true;
                _isGameStart = true;
               // _engine.aiLevel = 1;
            }
        }

        private void singleplayer_Updated(object source, EventArgs e)
        {
            MouseState mouse = Mouse.GetState();
            Sprite spr = (Sprite)source;
            if (mouse.X > spr.X && mouse.X < spr.X + spr.Width && mouse.Y > spr.Y && mouse.Y < spr.Y + spr.Height)
            {
                spriteManager.Sprites[2].Scale = new Vector2(1);
            }
            else
            {
                spriteManager.Sprites[2].Scale = new Vector2(0);
            }

            if (spr.ClickCheck())
            {
                _isMultiPlayer = false;
                _isGameStart = false;

                spriteManager.Sprites[0].Scale = new Vector2(0.2f, 0.2f);
                spriteManager.Sprites[1].Scale = new Vector2(0);
                spriteManager.Sprites[2].Scale = new Vector2(0);
                spriteManager.Sprites[3].Scale = new Vector2(0);
                spriteManager.Sprites[4].Scale = new Vector2(0);
                spriteManager.Sprites[5].Scale = new Vector2(0);
                spriteManager.Sprites[6].Scale = new Vector2(0);
                spriteManager.Sprites[7].Scale = new Vector2(0);
                spriteManager.Sprites[8].Scale = new Vector2(0);

                stan.Color = Color.Black;
                easy.Color = Color.Black;
                medium.Color = Color.Black;
            }
        }

        //difficulty level easy
        void easy_Updated(object sender, EventArgs e)
        {
            TextSprite spr = (TextSprite)sender;
            MouseState mouse = Mouse.GetState();

            if (easy.Color != Color.Transparent)
            {
                if (mouse.X > easy.X && mouse.X < easy.X + easy.Width && mouse.Y > easy.Y && mouse.Y < easy.Y + easy.Height)
                {
                    easy.Color = Color.Gold;
                }
                else
                {
                    easy.Color = Color.Black;
                }
            }

            if (mouse.X > spr.X && mouse.X < spr.X + spr.Width && mouse.Y > spr.Y && mouse.Y < spr.Y + spr.Height && mouse.LeftButton == ButtonState.Pressed)
            {
                _isMultiPlayer = false;
                _isGameStart = true;
                _engine.aiLevel = 1;

            }
        }

        //difficulty level stan
        void stan_Updated(object sender, EventArgs e)
        {
            TextSprite spr = (TextSprite)sender;
            MouseState mouse = Mouse.GetState();
            if (stan.Color != Color.Transparent)
            {
                if (mouse.X > stan.X && mouse.X < stan.X + stan.Width && mouse.Y > stan.Y && mouse.Y < stan.Y + stan.Height)
                {
                    stan.Color = Color.Gold;
                }
                else
                {
                    stan.Color = Color.Black;
                }
            }

            if (mouse.X > spr.X && mouse.X < spr.X + spr.Width && mouse.Y > spr.Y && mouse.Y < spr.Y + spr.Height && mouse.LeftButton == ButtonState.Pressed)
            {
                _isMultiPlayer = false;
                _isGameStart = true;
                _engine.aiLevel = 0;
            }
        }
    }
}
