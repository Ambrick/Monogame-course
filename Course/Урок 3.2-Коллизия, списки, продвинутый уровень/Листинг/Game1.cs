using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Lesson_3._2_Collision
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int ScreenWidth { get { return 500; } }
        public static int ScreenHeight { get { return 500; } }

        public static List <Circle> circles = new List<Circle>();
        public Square Master;


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


            Master = new Square( Content.Load<Texture2D>("square"), new Vector2(64, 400), "square", 2, this);
            for (int i=0; i<3; i++)
            {
                circles.Add(new Circle(Content.Load<Texture2D>("circle"), new Vector2(50 + i * 180, 50 + i * 180), "circle"));
            }
        }

        protected override void Update(GameTime gameTime)
        {
            Master.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            spriteBatch.Begin();
            Master.Draw(spriteBatch);

            foreach (GameComponent spr in circles)
                spr.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
