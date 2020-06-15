using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lesson_1._2
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        private Sprite sprite1;
        private Component sprite2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);
            
            //Объявление классов
            sprite1 = new Sprite(Content.Load<Texture2D>("pic"), new Vector2(50, 50));
            sprite2 = new Component(this, Content.Load<Texture2D>("pic"), new Vector2(120, 50));
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            spriteBatch.Begin();
            spriteBatch.Draw(sprite1.Texture, sprite1.Position, Color.White);
            spriteBatch.End();

            sprite2.Draw(gameTime);
        }
    }
}
