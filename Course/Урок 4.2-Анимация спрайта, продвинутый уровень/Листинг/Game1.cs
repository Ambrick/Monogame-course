using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Lesson_4_2_Animation
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Sprite sprite1;

        public static int ScreenWidth { get { return 500; }}
        public static int ScreenHeight { get { return 500; }}

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
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);

            sprite1 = new Sprite(new Dictionary<string, Animation>() {
                                 { "Move", new Animation(Content.Load<Texture2D>("Monster_run"), 8, 0.2f) },
                                 { "Hit", new Animation(Content.Load<Texture2D>("Monster_hit"), 5, 0.1f) } }, new Vector2(100, 100));
        }

        protected override void Update(GameTime gameTime)
        {
            sprite1.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            spriteBatch.Begin();
            sprite1.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
