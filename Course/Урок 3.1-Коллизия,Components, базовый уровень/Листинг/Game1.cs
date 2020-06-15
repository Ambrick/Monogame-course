using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Lesson_3._1_Collision
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int ScreenWidth { get { return 500; } }
        public static int ScreenHeight { get { return 500; } }
        private int circles_to_kill = 2;
        private double click__timer = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.ApplyChanges();

            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);

            Random rnd = new Random();
            for (int i=0; i < circles_to_kill; i++)
            {
                Components.Add(new Circle(this,Content.Load<Texture2D>("circle"), new Vector2 (ScreenWidth -100 , 1), "circle", rnd.Next(1,20)));
            }
        }

        protected override void Update(GameTime gameTime)
        {
            click__timer -= click__timer > 0 ? gameTime.ElapsedGameTime.TotalSeconds : 0;

            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Space) && click__timer <= 0)
            {
                Components.Add(new Square(this, Content.Load<Texture2D>("square"), new Vector2(0, ScreenHeight/2), "square", 12, this));
                click__timer= 0.5f;
            }

            foreach (GameComponent spr in Components)
            {
                if (spr.IsDead)
                {
                    Components.Remove(spr);
                    return;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);
            
            spriteBatch.Begin();
            base.Draw(gameTime);
            spriteBatch.End();
        }

        public void Kill()
        {
            circles_to_kill--;
            Components.Add(new Plus(this, Content.Load<Texture2D>("plus"), new Vector2((5 - circles_to_kill) * 70, ScreenHeight - 100), "plus"));
        }
    }
}
