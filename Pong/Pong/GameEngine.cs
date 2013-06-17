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

using Pong.ServiceReference1;
using Glib.XNA.SpriteLib;

namespace Pong
{
    public class GameEngine
    {
        private SpriteManager _spriteManager;
        private Viewport _viewport;
        private TimeSpan elapsedTime;
        private TimeSpan resetTimer;

        GameState state;

        KeyboardState oldKeyboardState;

        //private SpriteFont font;
        private bool _isMultiPlayer = false;

        public bool IsMultiPlayer
        {
            set
            {
                _isMultiPlayer = value;
            }
        }


        public GameEngine()
        {

        }

        Sprite p2gun;
        Sprite p1gun;

        Sprite p1gun2;
        Sprite p2gun2;

        Sprite p1gun3;
        Sprite p2gun3;

        Sprite ball;

        Sprite p1healthbar;
        Sprite p1healthempty;

        Sprite p2healthbar;
        Sprite p2healthempty;

        Texture2D bullet;

        TextSprite gameOver;

        Song gun;
        Song song;

        public void Load(SpriteBatch spriteBatch, ContentManager Content, Viewport viewport, bool useCustTexture, Texture2D custTexture)
        {
            SpriteFactory ballBuilder = new SpriteFactory(Content.Load<Texture2D>("PongCircle"), new Vector2(370, 180), spriteBatch).SetUpdateParamaters(new UpdateParamaters(true, true, false));
            ball = ballBuilder.Build();
            Sprite p1 = new SpriteFactory(useCustTexture ? custTexture : Content.Load<Texture2D>("PongSprite1"), new Vector2(0, 160), spriteBatch).SetScale(useCustTexture ? new Vector2(80f / custTexture.Width, 80f / custTexture.Height) : new Vector2(1, 1)).Build();
            Sprite p2 = new Sprite(Content.Load<Texture2D>("PongSprite2"), new Vector2(720, 160), spriteBatch);
            bullet = Content.Load<Texture2D>("bullet");
            p2gun = new Sprite(Content.Load<Texture2D>("gun"), new Vector2(viewport.Width - 150, 150 + p2.Height - 40), spriteBatch);
            p2gun.Scale /= 3;
            p2gun.UseCenterAsOrigin = false;
            p1gun = new Sprite(Content.Load<Texture2D>("gun"), new Vector2(10, 150 + p1.Height - 40), spriteBatch);
            p1gun.Scale /= 3;
            p1gun.UseCenterAsOrigin = false;

            p1gun2 = new Sprite(Content.Load<Texture2D>("gun2"), new Vector2(10, 150 + p1.Height - 40), spriteBatch);
            p2gun2 = new Sprite(Content.Load<Texture2D>("gun2"), new Vector2(viewport.Width - 150, 150 + p2.Height - 40), spriteBatch);

            p1gun2.Color = Color.Transparent;
            p2gun2.Color = Color.Transparent;

            p1gun2.UseCenterAsOrigin = false;
            p2gun2.UseCenterAsOrigin = false;

            p1gun3 = new Sprite(Content.Load<Texture2D>("gun3"), new Vector2(10, 150 + p1.Height - 40), spriteBatch);
            p2gun3 = new Sprite(Content.Load<Texture2D>("gun3"), new Vector2(viewport.Width - 150, 150 + p2.Height - 40), spriteBatch);

            p1gun3.Color = Color.Transparent;
            p2gun3.Color = Color.Transparent;

            p1gun3.UseCenterAsOrigin = false;
            p2gun3.UseCenterAsOrigin = false;

            p1gun3.Scale /= 1;
            p2gun3.Scale /= 1;

            p1healthbar = new Sprite(Content.Load<Texture2D>("full healf"), new Vector2(0), spriteBatch);
            p1healthempty = new Sprite(Content.Load<Texture2D>("healftempty"), new Vector2(0), spriteBatch);

            p2healthbar = new Sprite(Content.Load<Texture2D>("full healf"), new Vector2(605, 0), spriteBatch);
            p2healthempty = new Sprite(Content.Load<Texture2D>("healftempty"), new Vector2(605, 0), spriteBatch);

            p2healthbar.UseCenterAsOrigin = false;
            p2healthempty.UseCenterAsOrigin = false;

            p1healthbar.UseCenterAsOrigin = false;
            p1healthempty.UseCenterAsOrigin = false;

            p1healthbar.Color = Color.Transparent;
            p1healthempty.Color = Color.Transparent;

            p2healthbar.Color = Color.Transparent;
            p2healthempty.Color = Color.Transparent;

            p1gun.Color = Color.Transparent;
            p1gun.Updated += new EventHandler(gun_Updated);
            p2gun.Updated += new EventHandler(gun_Updated);
            p2gun.Color = Color.Transparent;

            ball.Updated += new EventHandler(ball_Updated);
            p1.Updated += new EventHandler(p1_Updated);
            p1.Move += new SpriteMoveEventHandler(p1_Move);
            p2.Updated += new EventHandler(p2_Updated);
            p2.Move += new SpriteMoveEventHandler(p2_Move);
            p2gun.Effect = SpriteEffects.FlipHorizontally;

            gameOver = new TextSprite(spriteBatch, new Vector2(170, 220), Content.Load<SpriteFont>("SpriteFont1"), "GAME OVER", Color.Black);
            gameOver.Color = Color.Transparent;
           

            _spriteManager = new SpriteManager(spriteBatch, ball, p1, p2, p2gun, p1gun, p1healthempty, p1healthbar, p2healthempty, p2healthbar, p1gun2, p2gun2, p1gun3, p2gun3);

            _viewport = viewport;

            resetTimer = new TimeSpan(0, 0, 0, 0, 500);
            elapsedTime = new TimeSpan(0, 0, 0, 0, 0);

            gun = Content.Load<Song>("Truth of the Legend");
            song = Content.Load<Song>("Cut and Run");

            state = GameState.Play;

        }

        int bulletYOffset = 20;

        void gun_Updated(object src, EventArgs ea)
        {
            Keys[] pressed = Keyboard.GetState().GetPressedKeys();
            if (pressed.Contains(Keys.RightAlt) && pressed.Contains(Keys.G))
            {

                MediaPlayer.Play(gun);

                p1gun.Color = Color.White;
                p2gun.Color = Color.White;

                p1gun2.Color = Color.Transparent;
                p2gun2.Color = Color.Transparent;

                p1gun3.Color = Color.Transparent;
                p2gun3.Color = Color.Transparent;

                p1healthbar.Color = Color.White;
                p1healthempty.Color = Color.White;

                p2healthbar.Color = Color.White;
                p2healthempty.Color = Color.White;

                ball.Color = Color.Transparent;
            }

            if (pressed.Contains(Keys.RightAlt) && pressed.Contains(Keys.S))
            {

                p1gun2.Color = Color.White;
                p2gun2.Color = Color.White;

                p1gun.Color = Color.Transparent;
                p2gun.Color = Color.Transparent;

                p1gun3.Color = Color.Transparent;
                p2gun3.Color = Color.Transparent;

                p1healthbar.Color = Color.White;
                p1healthempty.Color = Color.White;

                p2healthbar.Color = Color.White;
                p2healthempty.Color = Color.White;

                p2gun2.Effect = SpriteEffects.FlipHorizontally;

                ball.Color = Color.Transparent;
            }

            if (pressed.Contains(Keys.RightAlt) && pressed.Contains(Keys.H))
            {

                p1gun3.Color = Color.White;
                p2gun3.Color = Color.White;

                p1gun.Color = Color.Transparent;
                p2gun.Color = Color.Transparent;

                p1gun.Color = Color.Transparent;
                p2gun.Color = Color.Transparent;

                p1healthbar.Color = Color.White;
                p1healthempty.Color = Color.White;

                p2healthbar.Color = Color.White;
                p2healthempty.Color = Color.White;

                p1gun3.Effect = SpriteEffects.FlipHorizontally;

                ball.Color = Color.Transparent;
            }

            if (r.Next(45) == 12 && p1gun3.Color == Color.White && p2gun3.Color == Color.White)
            {
                //TODO: Shoot both guns
                Sprite bullet1 = new Sprite(bullet, p1gun3.Position, _spriteManager.Sprites[0].SpriteBatch);
                Sprite bullet2 = new Sprite(bullet, p2gun3.Position, _spriteManager.Sprites[0].SpriteBatch);

                bullet2.XSpeed = -3;
                bullet1.XSpeed = 3;


                bullet1.X += p1gun3.Width;
                bullet1.Y += bulletYOffset;

                bullet2.Y += bulletYOffset;
                bullet1.UpdateParams.UpdateX = true;
                bullet2.UpdateParams.UpdateX = true;

                bullet1.Updated += new EventHandler(bullet1_Updated);
                bullet2.Updated += new EventHandler(bullet2_Updated);

                _spriteManager.Sprites.Add(bullet1);
                _spriteManager.Sprites.Add(bullet2);

                //Fire!
            }

            if (r.Next(45) == 12 && p1gun2.Color == Color.White && p2gun2.Color == Color.White)
            {
                //TODO: Shoot both guns
                Sprite bullet1 = new Sprite(bullet, p1gun2.Position, _spriteManager.Sprites[0].SpriteBatch);
                Sprite bullet2 = new Sprite(bullet, p2gun2.Position, _spriteManager.Sprites[0].SpriteBatch);

                bullet2.XSpeed = -3;
                bullet1.XSpeed = 3;


                bullet1.X += p1gun2.Width;
                bullet1.Y += bulletYOffset;

                bullet2.Y += bulletYOffset;
                bullet1.UpdateParams.UpdateX = true;
                bullet2.UpdateParams.UpdateX = true;

                bullet1.Updated += new EventHandler(bullet1_Updated);
                bullet2.Updated += new EventHandler(bullet2_Updated);

                _spriteManager.Sprites.Add(bullet1);
                _spriteManager.Sprites.Add(bullet2);

                //Fire!
            }

            if (r.Next(45) == 12 && p1gun.Color == Color.White && p2gun.Color == Color.White)
            {
                //TODO: Shoot both guns
                Sprite bullet1 = new Sprite(bullet, p1gun.Position, _spriteManager.Sprites[0].SpriteBatch);
                Sprite bullet2 = new Sprite(bullet, p2gun.Position, _spriteManager.Sprites[0].SpriteBatch);

                bullet2.XSpeed = -3;
                bullet1.XSpeed = 3;
                

                bullet1.X += p1gun.Width;
                bullet1.Y += bulletYOffset;

                bullet2.Y += bulletYOffset;
                bullet1.UpdateParams.UpdateX = true;
                bullet2.UpdateParams.UpdateX = true;

                bullet1.Updated += new EventHandler(bullet1_Updated);
                bullet2.Updated += new EventHandler(bullet2_Updated);

                _spriteManager.Sprites.Add(bullet1);
                _spriteManager.Sprites.Add(bullet2);
                
                //Fire!
            }
        }

        void bullet1_Updated(object sender, EventArgs e)
        {
            Sprite shotBullet = (Sprite)sender;

            if(shotBullet.Intersects(_spriteManager[2]))
            {
                p2healthbar.Scale.X -= 0.1f;
                _spriteManager.Remove(shotBullet);
            }
        }

        void bullet2_Updated(object sender, EventArgs e)
        {
            Sprite shotBullet = (Sprite)sender;

            if (shotBullet.Intersects(_spriteManager[1]))
            {
                p1healthbar.Scale.X -= 0.1f;
                _spriteManager.Remove(shotBullet);
            }
        }

        void p2_Move(object source, Glib.XNA.SpriteMoveEventArgs e)
        {
            if (!e.Cancel)
            {
                p2gun.Position -= e.OldPosition - e.NewPosition;
                p2gun2.Position -= e.OldPosition - e.NewPosition;
            }
        }

        void p1_Move(object source, Glib.XNA.SpriteMoveEventArgs e)
        {
            if (!e.Cancel)
            {
                p1gun.Position -= e.OldPosition - e.NewPosition;
                p1gun2.Position -= e.OldPosition - e.NewPosition;
            }
        }
          
        public void Update(GameTime gameTime)
        {
            if (state == GameState.Play)
            {
                _spriteManager.Update();
            }

            if (p2healthbar.Scale.X <= 0)
            {
                gameOver.Color = Color.White;
            }
            if (p1healthbar.Scale.X <= 0)
            {
                gameOver.Color = Color.White;
            }


            KeyboardState keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.P) && oldKeyboardState.IsKeyUp(Keys.P))
            {
                state = (GameState)(Convert.ToInt32(state) * -1);
            }
                //PongHighscoresClient highscore = new PongHighscoresClient();
                //highscore.SendHighscore(0, "Joe", 0);
                //foreach (Highscore h in highscore.GetHighestScores())
                //{
                //    //displayScore(h.Name, h.Score, h.H
                //}
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _spriteManager.Draw();
        }

        private void ball_Updated(object source, EventArgs e)
        {
            KeyboardState keyboard = Keyboard.GetState();
            Keys[] pressedKeys = keyboard.GetPressedKeys();

            if (pressedKeys.Contains(Keys.Space))
            {
                ((Sprite)source).XSpeed = -10;
                ((Sprite)source).YSpeed = 5f;
            }

            Rectangle paddle1 = new Rectangle(Convert.ToInt32(_spriteManager.Sprites[1].Position.X), Convert.ToInt32(_spriteManager.Sprites[1].Position.Y), Convert.ToInt32(_spriteManager.Sprites[1].Width), Convert.ToInt32(_spriteManager.Sprites[1].Height));

            Rectangle paddle2 = new Rectangle(Convert.ToInt32(_spriteManager.Sprites[2].Position.X), Convert.ToInt32(_spriteManager.Sprites[2].Position.Y), Convert.ToInt32(_spriteManager.Sprites[2].Width), Convert.ToInt32(_spriteManager.Sprites[2].Height));

            Rectangle ball = new Rectangle(Convert.ToInt32(_spriteManager.Sprites[0].Position.X), Convert.ToInt32(_spriteManager.Sprites[0].Position.Y), Convert.ToInt32(_spriteManager.Sprites[0].Width), Convert.ToInt32(_spriteManager.Sprites[0].Height));

            if (ball.Y + ball.Height >= _viewport.Height || ball.Y <= 0)
            {
                ((Sprite)source).YSpeed *= -1;
            }

            if (paddle1.Intersects(ball) || paddle2.Intersects(ball))
            {
                ((Sprite)source).XSpeed *= -1;
            }

            if (ball.X < 0 || ball.X + ball.Width > _viewport.Width)
            {
                ((Sprite)source).Position = new Vector2(370, 180);
                ((Sprite)source).XSpeed = 0;
                ((Sprite)source).YSpeed = 0;
            }
        }

        public int aiLevel = 0;
        private int unbeatable = 3;

        private void p1_Updated(object source, EventArgs e)
        {

            Rectangle paddle1 = new Rectangle(Convert.ToInt32(_spriteManager.Sprites[1].Position.X), Convert.ToInt32(_spriteManager.Sprites[1].Position.Y), Convert.ToInt32(_spriteManager.Sprites[1].Width), Convert.ToInt32(_spriteManager.Sprites[1].Height));

            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
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

            if (paddle1.Y + paddle1.Height > _viewport.Height)
            {
                ((Sprite)source).Y = _viewport.Height - paddle1.Height - 1;
            }
            if (paddle1.Y < 0)
            {
                ((Sprite)source).Y = 1;
            }
        }

        Random r = new Random();

        private void p2_Updated(object source, EventArgs e)
        {
            Rectangle paddle2 = new Rectangle(Convert.ToInt32(_spriteManager.Sprites[2].Position.X), Convert.ToInt32(_spriteManager.Sprites[2].Position.Y), Convert.ToInt32(_spriteManager.Sprites[2].Width), Convert.ToInt32(_spriteManager.Sprites[2].Height));

            if (_isMultiPlayer)
            {
                Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
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

                if (paddle2.Y + paddle2.Height > _viewport.Height)
                {
                    ((Sprite)source).Y = _viewport.Height - paddle2.Height - 1;
                }
                if (paddle2.Y < 0)
                {
                    ((Sprite)source).Y = 1;
                }
            }
            else
            {
                bool ballIsMoving = _spriteManager.Sprites[0].XSpeed > 0 || _spriteManager.Sprites[0].YSpeed > 0;
                if (ballIsMoving)
                {
                    if (aiLevel == unbeatable)
                    {
                        ((Sprite)source).Y = _spriteManager.Sprites[0].Position.Y;
                    }
                    else if (aiLevel == 1)
                    {
                        bool rbool = r.NextDouble() <= .5;
                        ((Sprite)source).Y += rbool ? -r.Next(4) : r.Next(4);
                        if ( ( ((Sprite)source).Y < 0 || ((Sprite)source).Y > _viewport.Height ) && r.NextDouble() <= .5)
                        {
                            ((Sprite)source).Y -= rbool ? -5 : 5;
                        }
                    }
                    else if (aiLevel == 2)
                    {
                        bool rbool = r.Next(105) == 52 || ((Sprite)source).Y == _spriteManager.Sprites[0].Position.Y || ((Sprite)source).Y == _spriteManager.Sprites[0].Position.X;
                        ((Sprite)source).Y -= rbool ? -r.Next(4) : r.Next(4);
                        if ((((Sprite)source).Y < 0 || ((Sprite)source).Y > _viewport.Height) && r.NextDouble() <= 1)
                        {
                            ((Sprite)source).Y -= rbool ? -5 : 5;
                        }  
                    }
                }
            }
        }
    }
}
