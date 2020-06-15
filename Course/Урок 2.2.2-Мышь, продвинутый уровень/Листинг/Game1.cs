using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lesson_2_Rotation_Camera
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Sprite sprite1;
        private Texture2D floor_txtr;

        public static int ScreenWidth { get { return 300; } }
        public static int ScreenHeight { get { return 300; } }

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

            sprite1 = new Sprite(Content.Load<Texture2D>("pers"), new Vector2(100, 100));
            floor_txtr = Content.Load<Texture2D>("Floor");
        }

        protected override void Update(GameTime gameTime)
        {
            Camera.Follow(sprite1.Properties);
            sprite1.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            spriteBatch.Begin(transformMatrix: Camera.Transform);
            spriteBatch.Draw(floor_txtr, Vector2.Zero, Color.White);
            sprite1.Draw(spriteBatch);
            spriteBatch.End();

        }
    }
}
