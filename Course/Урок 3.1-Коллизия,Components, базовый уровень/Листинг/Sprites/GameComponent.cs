using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lesson_3._1_Collision
{
    public class GameComponent : DrawableGameComponent
    {
        protected int pix_per_step;
        protected Vector2 Velocity;
        protected Vector2 position;
        protected Texture2D texture;

        public GameComponent(Game game, Texture2D texture, Vector2 position, string Object_type) : base(game) { }

        public Vector2 Velo { get { return Velocity; } set => Velocity = value; }
        public string Object_type { get; set; }
        public bool IsDead { get; set; } = false;
        public Vector2 Position { get { return position; } set => position = value; }
        public Rectangle Rectangle { get; protected set; }
        public Rectangle Properties => new Rectangle((int)Position.X - Rectangle.Width / 2, (int)Position.Y - Rectangle.Height / 2, Rectangle.Width, Rectangle.Height);
        
        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sprBatch = (SpriteBatch) Game.Services.GetService(typeof(SpriteBatch));

            sprBatch.Draw(texture, Position, Color.White);
            base.Draw(gameTime);
        }
    }
}
